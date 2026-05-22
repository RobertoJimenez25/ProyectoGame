using UnityEngine;

public class ResetObjeto : MonoBehaviour
{
    Vector3 posicionInicial;
    Quaternion rotacionInicial;

    Rigidbody rb;

    void Start()
    {
        posicionInicial =
        transform.position;

        rotacionInicial =
        transform.rotation;

        rb =
        GetComponent<Rigidbody>();
    }

    public void Reiniciar()
    {
        transform.position =
        posicionInicial;

        transform.rotation =
        rotacionInicial;

        if (rb != null)
        {
            rb.linearVelocity =
            Vector3.zero;

            rb.angularVelocity =
            Vector3.zero;
        }
    }
}