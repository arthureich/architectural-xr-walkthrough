using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))] 
public class ControladorDePortaDeslizante : MonoBehaviour
{
    public Vector3 deslocamentoAbertura;
    public float velocidadeAnimacao = 2.0f;
    public AudioClip somAbrindo;
    public AudioClip somFechando;
    private AudioSource audioSource;
    private bool portaAberta = false;
    private bool jogadorPerto = false;
    private Vector3 posicaoFechada;
    private Vector3 posicaoAberta;
    private Coroutine animacaoCoroutine;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        posicaoFechada = transform.position;
        posicaoAberta = posicaoFechada + deslocamentoAbertura;
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
            animacaoCoroutine = StartCoroutine(MoverPorta(posicaoFechada));
        }
        else
        {
            if (somAbrindo != null) audioSource.PlayOneShot(somAbrindo);
            animacaoCoroutine = StartCoroutine(MoverPorta(posicaoAberta));
        }

        portaAberta = !portaAberta;
    }
    private IEnumerator MoverPorta(Vector3 targetPosition)
    {
        float tempo = 0;
        Vector3 startPosition = transform.position;

        while (tempo < 1)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, tempo);
            tempo += Time.deltaTime * velocidadeAnimacao;
            yield return null;
        }

        transform.position = targetPosition;
    }
}