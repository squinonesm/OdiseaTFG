using UnityEngine;

public class Estalagmita : MonoBehaviour
{
    [SerializeField] private float tiempoEntreDaño = 1f;
    [SerializeField] private float daño = 1f;
    private float tiempoSiguienteDaño;

    private void Start()
    {
        tiempoSiguienteDaño = Time.time;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player") && Time.time >= tiempoSiguienteDaño)
        {
            CombateJugador jugador = other.collider.GetComponent<CombateJugador>();
            if (jugador != null && jugador.puedeRecibirDaño)
            {
                jugador.TomarDaño(daño);
                tiempoSiguienteDaño = Time.time + tiempoEntreDaño;
            }
        }
    }
}