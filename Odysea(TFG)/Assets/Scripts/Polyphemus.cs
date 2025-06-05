using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polyphemus : MonoBehaviour
{
    public float retrasoCanvas = 2f; 
    
    public GameObject dialogoBoss;

    private Animator animator;

    public Rigidbody2D rb2D;

    public Transform jugador;

    private bool mirandoDerecha = true;

    [Header("Vida")]
    [SerializeField] private float vida;
    [SerializeField] private float maximoVida;
    [SerializeField] private BarraDeVida barraDeVida;

    [Header("Ataque")]
    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float dañoAtaque;

    void Start()
    {
     animator = GetComponent<Animator>();
     rb2D = GetComponent<Rigidbody2D>();
     vida = maximoVida;
     barraDeVida.InicializarBarraDeVida(vida);
     jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void Update()
    {
        float distanciaJugador = Vector2.Distance(transform.position, jugador.position);
        animator.SetFloat("distanciaJugador", distanciaJugador);
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;

        barraDeVida.CambiarVidaActual(vida);
        GetComponent<FlashEffect>().Flash();

        if (vida <= 0)
        {
            animator.SetTrigger("Muerte");
        }
    }
    private IEnumerator RetrasoTrasMuerte()
    {
        yield return new WaitForSeconds(retrasoCanvas);

        if (dialogoBoss != null)
        {
            dialogoBoss.SetActive(true);
        }
        Destroy(gameObject, 1f);
    }


    private void Muerte()
    {
       
        StartCoroutine(RetrasoTrasMuerte());
    }

    public void MirarJugador()
    {
        if ((jugador.position.x > transform.position.x && !mirandoDerecha) ||
            (jugador.position.x < transform.position.x && mirandoDerecha))
        {
            mirandoDerecha = !mirandoDerecha;

            Vector3 escala = transform.localScale;
            escala.x *= -1;
            transform.localScale = escala;
        }
    }

    public void Ataque()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);

        foreach(Collider2D colision in objetos)
        {
            if (colision.CompareTag("Player"))
            {
                colision.GetComponent<CombateJugador>().TomarDaño(dañoAtaque);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaque.position,radioAtaque);
    }
}
