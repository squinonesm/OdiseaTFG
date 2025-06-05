using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateJugador : MonoBehaviour
{
    [SerializeField] private float vida;

    [SerializeField] private float maximoVida;

    [SerializeField] private BarraDeVida barraDeVida;

    [SerializeField] private float tiempoInvencibilidad = 1f;

    [SerializeField] private Reaparecer revivir;

    public bool puedeRecibirDa�o = true;

    private void Start()
    {
        vida = maximoVida;
        barraDeVida.InicializarBarraDeVida(vida);

        revivir = GetComponent<Reaparecer>();
    }

    public void TomarDa�o(float da�o)
    {
        if (!puedeRecibirDa�o || vida <= 0) return;

        puedeRecibirDa�o = false;

        vida -= da�o;
        vida = Mathf.Clamp(vida, 0, maximoVida);

        if (barraDeVida != null)
        {
            barraDeVida.CambiarVidaActual(vida);
        }

        GetComponent<FlashEffect>().Flash();
        StartCoroutine(ActivarInvencibilidad());

        if (vida <= 0)
        {
            puedeRecibirDa�o = false;
            revivir.Die();
        }
    }

    private IEnumerator ActivarInvencibilidad()
    {
        Debug.Log("Invencibilidad activada.");
        yield return new WaitForSeconds(tiempoInvencibilidad);
        puedeRecibirDa�o = true;
        Debug.Log("Invencibilidad terminada.");
    }

    public void RestaurarVida()
    {
        vida = maximoVida;
        barraDeVida.CambiarVidaActual(vida);
    }
}