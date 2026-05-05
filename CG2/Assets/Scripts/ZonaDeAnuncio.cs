using UnityEngine;

public class ZonaDeAnuncio : MonoBehaviour
{
    public string nomeDaArea;
    private GerenciadorUI gerenciadorUI;

    void Start()
    {
        gerenciadorUI = FindObjectOfType<GerenciadorUI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gerenciadorUI != null)
        {
            gerenciadorUI.EntrouNaZona(nomeDaArea);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && gerenciadorUI != null)
        {
            gerenciadorUI.SaiuDaZona(nomeDaArea);
        }
    }
}