using UnityEngine;

public class CameraJugador : MonoBehaviour
{
    public Transform target; // El objeto que la cámara seguirá (tu personaje)
    public float smoothSpeed = 0.125f; // Suavizado del movimiento de la cámara
    public Vector3 offset; // Ajuste de la posición de la cámara respecto al personaje

    void LateUpdate()
    {
        if (target != null)
        {
            // Calcula la posición deseada de la cámara
            Vector3 desiredPosition = target.position + offset;

            // Suaviza el movimiento de la cámara
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Asigna la nueva posición a la cámara
            transform.position = smoothedPosition;
        }
    }

}