using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformasCaida : MonoBehaviour
{
    [SerializeField] private float tiempoEspera;

    private Rigidbody2D rb2D;

    [SerializeField] private float velocidadRotacion;

    private Animator animator;

    private bool caida = false;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (caida)
        {
            transform.Rotate(new Vector3(0, 0, -velocidadRotacion * Time.deltaTime));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Caida(other));
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Peligro"))
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Caida(Collision2D other)
    {
        yield return new WaitForSeconds(tiempoEspera);
        caida = true;
        Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), other.transform.GetComponent<Collider2D>());
        rb2D.constraints = RigidbodyConstraints2D.None;
        rb2D.AddForce(new Vector2(0.1f, 0));
    }

}