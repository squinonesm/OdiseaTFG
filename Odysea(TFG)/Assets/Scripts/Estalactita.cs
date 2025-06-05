using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estalactita : MonoBehaviour
{

    public Rigidbody2D rbd2D;

    public float distanciaLinea;

    public LayerMask capa;

    public Transform jugador;

    [SerializeField] private float dañoImpacto;

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        RaycastHit2D info = Physics2D.Raycast(transform.position, Vector3.down, distanciaLinea, capa);

        if (info)
        {
            rbd2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("suelo"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            jugador.GetComponent<CombateJugador>().TomarDaño(dañoImpacto);
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * distanciaLinea);
    }
}
