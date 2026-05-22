using UnityEngine;
using System.Collections;
using StarterAssets;

public class PowerUpVelocidad : MonoBehaviour
{
    public float velocidadNueva = 13;
    public float velocidadNormal = 5;
    public float duracion = 10;
    public float tiempoRespawn = 15;

    Renderer rend;
    Collider col;

    ThirdPersonController jugadorActual;

    bool activo = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        col = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !activo)
        {
            jugadorActual =
            other.GetComponent<ThirdPersonController>();

            if (jugadorActual != null)
            {
                StartCoroutine(
                ActivarPower());
            }
        }
    }

    IEnumerator ActivarPower()
    {
        activo = true;

        jugadorActual.MoveSpeed =
        velocidadNueva;

        jugadorActual.SprintSpeed =
        velocidadNueva;

        rend.enabled = false;
        col.enabled = false;

        yield return
        new WaitForSeconds(duracion);

        ReiniciarVelocidad();

        yield return
        new WaitForSeconds(
        tiempoRespawn);

        Reaparecer();
    }

    public void ReiniciarVelocidad()
    {
        StopAllCoroutines();

        activo = false;

        if (jugadorActual != null)
        {
            jugadorActual.MoveSpeed =
            velocidadNormal;

            jugadorActual.SprintSpeed =
            velocidadNormal;
        }

        rend.enabled = true;
        col.enabled = true;

        Debug.Log(
        "Velocidad reiniciada");
    }

    public void Reaparecer()
    {
        activo = false;

        rend.enabled = true;
        col.enabled = true;
    }
}