using UnityEngine;

public class CameraJugador : MonoBehaviour
{
    public Transform target; // El objeto que la c�mara seguir� (tu personaje)
    public float smoothSpeed = 0.125f; // Suavizado del movimiento de la c�mara
    public Vector3 offset; // Ajuste de la posici�n de la c�mara respecto al personaje

    void LateUpdate()
    {
        if (target != null)
        {
            // Calcula la posici�n deseada de la c�mara
            Vector3 desiredPosition = target.position + offset;

            // Suaviza el movimiento de la c�mara
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Asigna la nueva posici�n a la c�mara
            transform.position = smoothedPosition;
        }
    }

}