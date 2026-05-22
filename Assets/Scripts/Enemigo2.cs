using UnityEngine;
using System.Collections;

public class Enemigo2 : MonoBehaviour
{
    public Transform[] puntos;
    public Transform jugador;

    public float velocidad = 3;
    public float distanciaDeteccion = 6;
    public float velocidadPersecucion = 5;
    public float distanciaCaptura = 1.5f;

    PantallaMuerte muerte;

    int puntoActual = 0;

    bool capturado = false;

    void Start()
    {
        muerte =
        FindAnyObjectByType<
        PantallaMuerte>();
    }

    void Update()
    {
        if (capturado)
            return;

        float distanciaJugador =
        Vector3.Distance(
        transform.position,
        jugador.position);

        if (distanciaJugador <= distanciaCaptura)
        {
            StartCoroutine(
            CapturarJugador());
        }

        // perseguir
        else if (distanciaJugador <=
        distanciaDeteccion)
        {
            transform.position =
            Vector3.MoveTowards(
            transform.position,
            jugador.position,
            velocidadPersecucion *
            Time.deltaTime);
        }

        // patrulla
        else
        {
            if (puntos.Length == 0)
                return;

            transform.position =
            Vector3.MoveTowards(
            transform.position,
            puntos[puntoActual].position,
            velocidad *
            Time.deltaTime);

            if (Vector3.Distance(
            transform.position,
            puntos[puntoActual].position)
            < 0.5f)
            {
                puntoActual++;

                if (puntoActual >=
                puntos.Length)
                {
                    puntoActual = 0;
                }
            }
        }
    }

    IEnumerator CapturarJugador()
    {
        capturado = true;

        Debug.Log("TE ATRAPÓ");

        if (muerte != null)
        {
            muerte.MostrarMuerte();
        }

        yield return
        new WaitForSeconds(2);

        Telekinesis tele =
        jugador.GetComponent<
        Telekinesis>();

        if (tele != null)
        {
            tele.SoltarObjeto();
        }

        CharacterController cc =
        jugador.GetComponent<
        CharacterController>();

        if (cc != null)
            cc.enabled = false;

        jugador.position =
        new Vector3(
        -17.86f,
        18.58f,
        -24.62f);

        if (cc != null)
            cc.enabled = true;

        ResetObjeto[] objetos =
        FindObjectsByType<
        ResetObjeto>(
        FindObjectsSortMode.None);

        foreach (
        ResetObjeto obj
        in objetos)
        {
            obj.Reiniciar();
        }

        PowerUpVelocidad power =
        FindAnyObjectByType<
        PowerUpVelocidad>();

        if (power != null)
        {
            power.Reaparecer();
            power.ReiniciarVelocidad();
        }

        capturado = false;
    }
}