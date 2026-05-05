using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorMenuPausa : MonoBehaviour
{
    public GameObject painelDePausa;

    private bool estaPausado = false;

    void Start()
    {
        painelDePausa.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (estaPausado)
            {
                Retomar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Pausar()
    {
        painelDePausa.SetActive(true);
        Time.timeScale = 0f; 
        estaPausado = true;
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;
    }

    public void Retomar()
    {
        painelDePausa.SetActive(false);
        Time.timeScale = 1f; 
        estaPausado = false;
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
    }

    public void VoltarAoMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}