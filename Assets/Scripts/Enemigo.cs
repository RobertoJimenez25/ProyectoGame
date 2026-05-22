using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Transform[] puntos;

    public Transform jugador;

    public float velocidad = 3;
    public float distanciaDeteccion = 6;
    public float velocidadPersecucion = 5;
    public float distanciaCaptura = 1.5f;

    int puntoActual = 0;

    void Update()
    {
        float distanciaJugador =
        Vector3.Distance(
        transform.position,
        jugador.position);

        // capturó
        if (distanciaJugador <= distanciaCaptura)
        {
            Debug.Log("TE ATRAPÓ");

            // soltar caja
            Telekinesis tele =
            jugador.GetComponent<Telekinesis>();

            if (tele != null)
            {
                tele.SoltarObjeto();
            }

            // apagar controller
            CharacterController cc =
            jugador.GetComponent<
            CharacterController>();

            if (cc != null)
            {
                cc.enabled = false;
            }

            // mover jugador inicio
            jugador.position =
            new Vector3(
            1.2f,
            23.71f,
            34.71f);

            // volver activar controller
            if (cc != null)
            {
                cc.enabled = true;
            }

            // reiniciar cajas
            ResetObjeto[] objetos =
            FindObjectsByType<ResetObjeto>(
            FindObjectsSortMode.None);

            foreach (ResetObjeto obj
            in objetos)
            {
                obj.Reiniciar();
            }

            // reiniciar powerup
            PowerUpVelocidad power =
            FindAnyObjectByType<
            PowerUpVelocidad>();

            if (power != null)
            {
                power.Reaparecer();

                power.ReiniciarVelocidad();
            }

            return;
        }

        // perseguir
        if (distanciaJugador <=
        distanciaDeteccion)
        {
            transform.position =
            Vector3.MoveTowards(
            transform.position,
            jugador.position,
            velocidadPersecucion
            * Time.deltaTime);

            return;
        }

        // patrulla
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