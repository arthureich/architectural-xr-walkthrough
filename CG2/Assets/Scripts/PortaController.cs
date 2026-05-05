using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PortaController : MonoBehaviour
{
    public Collider colisorFisico;

    public float anguloAbertura = 90.0f;
    public float velocidadeAnimacao = 2.0f;

    public AudioClip somAbrindo;
    public AudioClip somFechando;
    private AudioSource audioSource;
    private bool portaAberta = false;
    private bool jogadorPerto = false;

    private Quaternion rotacaoFechada;
    private Quaternion rotacaoAberta;

    private Coroutine animacaoCoroutine;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        rotacaoFechada = transform.rotation;
        rotacaoAberta = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + anguloAbertura, transform.eulerAngles.z);

        if (colisorFisico != null)
        {
            colisorFisico.enabled = true;
        }
    }

    void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.E))
        {
            ExecutarAcaoPorta();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
        }
    }

    public void ExecutarAcaoPorta()
    {
        if (animacaoCoroutine != null)
        {
            StopCoroutine(animacaoCoroutine);
        }

        if (portaAberta)
        {
            if (somFechando != null) audioSource.PlayOneShot(somFechando);
            animacaoCoroutine = StartCoroutine(MoverPorta(rotacaoFechada, false));
        }
        else
        {
            if (somAbrindo != null) audioSource.PlayOneShot(somAbrindo);
            animacaoCoroutine = StartCoroutine(MoverPorta(rotacaoAberta, true)); 
        }

        portaAberta = !portaAberta;
    }

    private IEnumerator MoverPorta(Quaternion targetRotation, bool estaAbrindo)
    {
        if (!estaAbrindo && colisorFisico != null)
        {
            colisorFisico.enabled = true;
        }

        float tempo = 0;
        Quaternion startRotation = transform.rotation;

        while (tempo < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, tempo);
            tempo += Time.deltaTime * velocidadeAnimacao;
            yield return null;
        }
        transform.rotation = targetRotation;

        if (estaAbrindo && colisorFisico != null)
        {
            colisorFisico.enabled = false;
        }
    }
}