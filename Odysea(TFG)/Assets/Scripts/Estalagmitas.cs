using UnityEngine;

public class Estalagmita : MonoBehaviour
{
    [SerializeField] private float tiempoEntreDa�o = 1f;
    [SerializeField] private float da�o = 1f;
    private float tiempoSiguienteDa�o;

    private void Start()
    {
        tiempoSiguienteDa�o = Time.time;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player") && Time.time >= tiempoSiguienteDa�o)
        {
            CombateJugador jugador = other.collider.GetComponent<CombateJugador>();
            if (jugador != null && jugador.puedeRecibirDa�o)
            {
                jugador.TomarDa�o(da�o);
                tiempoSiguienteDa�o = Time.time + tiempoEntreDa�o;
            }
        }
    }
}