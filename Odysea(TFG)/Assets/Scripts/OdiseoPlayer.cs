using UnityEngine;

public class OdiseoPlayer : MonoBehaviour
{
    public float Speed;
    public float JumpForce;


    private Animator animator;
    private Rigidbody2D rb;
    private float horizontal;
    private bool grounded;

    [Header("Ground Detection")]
    public Transform ControladorSuelo;            
    public float groundCheckRadius = 0.2f;    
    public LayerMask suelo;             

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
     

        horizontal = Input.GetAxisRaw("Horizontal");

        // Rotación
        if (horizontal < 0.0f) transform.rotation = Quaternion.Euler(0, 180, 0);
        else if (horizontal > 0.0f) transform.rotation = Quaternion.Euler(0, 0, 0);

        animator.SetBool("Corriendo", horizontal != 0.0f);

        // Detección del suelo con Physics2D.OverlapCircle
        grounded = Physics2D.OverlapCircle(ControladorSuelo.position, groundCheckRadius, suelo);

        animator.SetBool("EnElAire", !grounded);

        // Saltar solo si está en el suelo
        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0); // Resetear salto previo
        rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);
    }

    // Visualiza el círculo del ControladorSuelo en el editor
    private void OnDrawGizmosSelected()
    {
        if (ControladorSuelo != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(ControladorSuelo.position, groundCheckRadius);
        }
    }
}
