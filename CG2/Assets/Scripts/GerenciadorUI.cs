using UnityEngine;
using TMPro;
using System.Collections.Generic; 

public class GerenciadorUI : MonoBehaviour
{
    public TextMeshProUGUI textoNomeArea;

    private List<string> zonasAtivas = new List<string>();

    public void EntrouNaZona(string nomeDaZona)
    {
        if (!zonasAtivas.Contains(nomeDaZona))
        {
            zonasAtivas.Add(nomeDaZona);
        }
        AtualizarTexto();
    }

    public void SaiuDaZona(string nomeDaZona)
    {

        if (zonasAtivas.Contains(nomeDaZona))
        {
            zonasAtivas.Remove(nomeDaZona);
        }
        AtualizarTexto();
    }

    private void AtualizarTexto()
    {
        if (zonasAtivas.Count == 0)
        {
            textoNomeArea.text = "";
        }
        else
        {
        
            textoNomeArea.text = zonasAtivas[zonasAtivas.Count - 1];
        }
    }
}