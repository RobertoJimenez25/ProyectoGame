using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("Selector");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Salir");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Nivel1()
    {
        SceneManager.LoadScene("Nivel 1");
    }

    
}