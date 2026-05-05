using UnityEngine;

public class AudioSaida : MonoBehaviour
{
    public AudioSource audioExterno;
    public AudioSource audioInterno;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jogador saiu, trocando para som externo.");

            if (audioInterno != null && audioInterno.isPlaying)
            {
                audioInterno.Stop();
            }
            
            if (audioExterno != null && !audioExterno.isPlaying)
            {
                audioExterno.Play();
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