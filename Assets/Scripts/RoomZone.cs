using UnityEngine;

public class RoomZone : MonoBehaviour
{
    public PressureButton botonDelCuarto;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PressureButton.botonActual =
            botonDelCuarto;
        }
    }
}