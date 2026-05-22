using UnityEngine;
using StarterAssets;

public class Historia: MonoBehaviour
{
    public GameObject panelHistoria;

    ThirdPersonController jugador;

    void Start()
    {
        jugador =
        FindAnyObjectByType<
        ThirdPersonController>();

        Time.timeScale = 0;

        Cursor.lockState =
        CursorLockMode.None;

        Cursor.visible = true;

        jugador.enabled = false;
    }

    public void Continuar()
    {
        panelHistoria.SetActive(false);

        Time.timeScale = 1;

        Cursor.lockState =
        CursorLockMode.Locked;

        Cursor.visible = false;

        jugador.enabled = true;
    }
}