using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class PauseManager : MonoBehaviour
{
    public GameObject panelPausa;

    bool pausado = false;

    ThirdPersonController jugador;

    void Start()
    {
        jugador =
        FindAnyObjectByType<
        ThirdPersonController>();
    }

    void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            pausado = !pausado;

            panelPausa.SetActive(
            pausado);

            if (pausado)
            {
                Time.timeScale = 0;

                Cursor.lockState =
                CursorLockMode.None;

                Cursor.visible = true;

                jugador.enabled = false;
            }
            else
            {
                Time.timeScale = 1;

                Cursor.lockState =
                CursorLockMode.Locked;

                Cursor.visible = false;

                jugador.enabled = true;
            }
        }
    }

    public void Continuar()
    {
        pausado = false;

        panelPausa.SetActive(false);

        Time.timeScale = 1;

        Cursor.lockState =
        CursorLockMode.Locked;

        Cursor.visible = false;

        jugador.enabled = true;
    }

    public void Menu()
    {
        Time.timeScale = 1;

        UnityEngine.SceneManagement
        .SceneManager.LoadScene(
        "MainMenu");
    }

    public void Salir()
    {
        Application.Quit();

        Debug.Log("Salir");
    }
}