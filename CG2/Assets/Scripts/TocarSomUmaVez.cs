using UnityEngine;

// Garante que este script seja colocado em um objeto que tenha um Audio Source
[RequireComponent(typeof(AudioSource))]
public class TocarSomUmaVez : MonoBehaviour
{
    // Variável "lembrete" para saber se o som já foi tocado
    private bool jaTocou = false;
    
    // Referência para o nosso componente Audio Source
    private AudioSource audioSource;

    void Awake()
    {
        // Pega o componente Audio Source que está no mesmo objeto
        audioSource = GetComponent<AudioSource>();
    }

    // Esta função é chamada automaticamente pelo Unity quando algo entra no Trigger
    private void OnTriggerEnter(Collider other)
    {
        // 1. Verifica se quem entrou é o jogador E
        // 2. Verifica se o som ainda NÃO tocou
        if (other.CompareTag("Player") && !jaTocou)
        {
            // Se as duas condições forem verdadeiras, faça o seguinte:
            
            Debug.Log("Som de entrada tocou pela primeira vez!");

            // Toca o som que está no Audio Source
            audioSource.Play();
            
            // "Levanta a bandeira" para que esta condição nunca mais seja verdadeira
            jaTocou = true;
        }
    }
}