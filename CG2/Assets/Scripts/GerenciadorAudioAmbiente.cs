using UnityEngine;

public class GerenciadorAudioAmbiente : MonoBehaviour
{
    public AudioSource audioExterno;
    public AudioSource audioInterno;
    public AudioSource musicaInicial; 
    private bool musicaInicialJaParou = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!musicaInicialJaParou)
            {
                if (musicaInicial != null)
                {
                    musicaInicial.Stop(); 
                }
                musicaInicialJaParou = true; 
            }
            // -------------------
            
            if (audioExterno != null && audioExterno.isPlaying)
            {
                audioExterno.Stop();
            }
            
            if (audioInterno != null && !audioInterno.isPlaying)
            {
                audioInterno.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioInterno != null && audioInterno.isPlaying)
            {
                //audioInterno.Stop();
            }
            if (audioExterno != null && !audioExterno.isPlaying)
            {
                //audioExterno.Play();
            }
        }
    }
}