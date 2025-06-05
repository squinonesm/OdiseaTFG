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

    public bool puedeRecibirDaño = true;

    private void Start()
    {
        vida = maximoVida;
        barraDeVida.InicializarBarraDeVida(vida);

        revivir = GetComponent<Reaparecer>();
    }

    public void TomarDaño(float daño)
    {
        if (!puedeRecibirDaño || vida <= 0) return;

        puedeRecibirDaño = false;

        vida -= daño;
        vida = Mathf.Clamp(vida, 0, maximoVida);

        if (barraDeVida != null)
        {
            barraDeVida.CambiarVidaActual(vida);
        }

        GetComponent<FlashEffect>().Flash();
        StartCoroutine(ActivarInvencibilidad());

        if (vida <= 0)
        {
            puedeRecibirDaño = false;
            revivir.Die();
        }
    }

    private IEnumerator ActivarInvencibilidad()
    {
        Debug.Log("Invencibilidad activada.");
        yield return new WaitForSeconds(tiempoInvencibilidad);
        puedeRecibirDaño = true;
        Debug.Log("Invencibilidad terminada.");
    }

    public void RestaurarVida()
    {
        vida = maximoVida;
        barraDeVida.CambiarVidaActual(vida);
    }
}