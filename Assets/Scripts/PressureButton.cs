using UnityEngine;
using TMPro;

public class PressureButton : MonoBehaviour
{
    // botón activo del cuarto actual
    public static PressureButton botonActual;

    public GameObject puerta;

    // texto UI
    public TMP_Text textoPeso;

    public float pesoNecesario = 25;
    public float velocidad = 2;

    public float pesoActual = 0;

    bool abrir;

    Vector3 posicionCerrada;
    Vector3 posicionAbierta;

    void Start()
    {
        posicionCerrada = puerta.transform.position;

        // cuánto sube la puerta
        posicionAbierta =
        posicionCerrada + Vector3.up * 4;

        // primer cuarto por defecto
        if (botonActual == null)
        {
            botonActual = this;
        }
    }

    void Update()
    {
        // actualizar HUD solo del cuarto actual
        if (botonActual != null)
        {
            textoPeso.text =
            "<b>Peso requerido para este cuarto:</b> " +
            botonActual.pesoNecesario +

            " Kg\n\n" +

            "<b>Peso actual:</b> " +
            botonActual.pesoActual +
            "/" +
            botonActual.pesoNecesario +

            " Kg";
        }

        // mover puerta
        if (abrir)
        {
            puerta.transform.position =
            Vector3.Lerp(
                puerta.transform.position,
                posicionAbierta,
                Time.deltaTime * velocidad);
        }
        else
        {
            puerta.transform.position =
            Vector3.Lerp(
                puerta.transform.position,
                posicionCerrada,
                Time.deltaTime * velocidad);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb =
        other.GetComponent<Rigidbody>();

        if (rb != null)
        {
            pesoActual += rb.mass;

            RevisarPeso();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb =
        other.GetComponent<Rigidbody>();

        if (rb != null)
        {
            pesoActual -= rb.mass;

            RevisarPeso();
        }
    }

    void RevisarPeso()
    {
        if (pesoActual >= pesoNecesario)
        {
            abrir = true;
        }
        else
        {
            abrir = false;
        }
    }
}