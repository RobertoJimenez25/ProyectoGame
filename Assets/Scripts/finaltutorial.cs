using UnityEngine;
using StarterAssets;

public class FinalTutorial : MonoBehaviour
{
    public GameObject panelFinal;

    ThirdPersonController jugador;

    void Start()
    {
        jugador =
        FindAnyObjectByType<
        ThirdPersonController>();
    }

    private void OnTriggerEnter(
    Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panelFinal.SetActive(
            true);

            Time.timeScale = 0;

            Cursor.lockState =
            CursorLockMode.None;

            Cursor.visible = true;

            if (jugador != null)
            {
                jugador.enabled =
                false;
            }
        }
    }

    public void VolverMenu()
    {
        Time.timeScale = 1;

        UnityEngine.SceneManagement
        .SceneManager.LoadScene(
        "MainMenu");
    }
}