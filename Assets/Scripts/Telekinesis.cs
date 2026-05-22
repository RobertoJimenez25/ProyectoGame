using UnityEngine;
using UnityEngine.InputSystem;

public class Telekinesis : MonoBehaviour
{
    public float distancia = 10f;
    public Transform puntoSujecion;

    private Rigidbody objetoTomado;

    void Update()
    {
        // Tomar
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            Debug.Log("CLICK");

            if (objetoTomado == null)
            {
                RaycastHit hit;

                Debug.DrawRay(
                       Camera.main.transform.position,
                        Camera.main.transform.forward * distancia,
                Color.red);

                if (Physics.Raycast(
                Camera.main.transform.position,
                Camera.main.transform.forward,
                out hit,
                distancia,
                ~0,
                QueryTriggerInteraction.Ignore))
                {
                    Rigidbody rb =
                    hit.collider.GetComponent<Rigidbody>();

                    if (rb != null)
                    {
                        Debug.Log("OBJETO TOMADO");

                        objetoTomado = rb;

                        objetoTomado.useGravity = false;
                    }
                }
            }
        }

        // Soltar
        if (Mouse.current.rightButton.wasReleasedThisFrame)
        {
            if (objetoTomado != null)
            {
                objetoTomado.useGravity = true;

                objetoTomado = null;

                Debug.Log("SOLTADO");
            }
        }

        // Mantener delante
        if (objetoTomado != null)
        {
            objetoTomado.position =
            Vector3.Lerp(
            objetoTomado.position,
            puntoSujecion.position,
            Time.deltaTime * 10);
        }
    }
    public void SoltarObjeto()
    {
        if (objetoTomado != null)
        {
            objetoTomado.useGravity = true;

            objetoTomado = null;
        }
    }
}