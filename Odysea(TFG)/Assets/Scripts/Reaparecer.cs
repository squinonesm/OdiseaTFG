using UnityEngine;

public class Reaparecer : MonoBehaviour
{
    private Vector3 spawnPoint;
    private Rigidbody2D rb;
    private bool estaMuerto = false;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        SetInitialSpawnPoint();
        animator.SetBool("Muerte", false); // Inicializa el parámetro
    }

    void SetInitialSpawnPoint() => spawnPoint = transform.position;
    public void SetSpawnPoint(Vector3 newPosition) => spawnPoint = newPosition;

    public void Die()
    {
        if (estaMuerto) return;
        estaMuerto = true;

        // Activa el parámetro booleano
        if (animator != null) animator.SetBool("Muerte", true);

        // Congela la física
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.simulated = false; // Desactiva interacciones físicas
        }

        Invoke("Respawn", 1.0f);
    }

    private void Respawn()
    {
        transform.position = spawnPoint;
        estaMuerto = false;
        animator.SetBool("Muerte", false);

        if (rb != null) rb.simulated = true;

        GetComponent<CombateJugador>().puedeRecibirDaño = true;

        RecargarEscena.RecargarNivel();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Peligro"))
        {
            Die();
        }
    }

    private void Update()
    {
        if (transform.position.y < -25f) Die();
    }
}