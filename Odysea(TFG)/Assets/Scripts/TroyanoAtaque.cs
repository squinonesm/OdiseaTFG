using UnityEngine;

public class TroyanoAtaque : MonoBehaviour
{
    [SerializeField] private float da�oAtaque = 10f;

    private void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.CompareTag("Player"))
        {

            colision.GetComponent<CombateJugador>().TomarDa�o(da�oAtaque);

        }
    }
}
