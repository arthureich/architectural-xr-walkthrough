using UnityEngine;
using UnityEngine.SceneManagement; 

public class GerenciadorMenuPrincipal : MonoBehaviour
{
    public string nomeDaCenaDoJogo = "SampleScene";

    public void IniciarJogo()
    {
        SceneManager.LoadScene(nomeDaCenaDoJogo);
    }

    public void SairDoJogo()
    {
        Debug.Log("Saindo do jogo..."); 
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}