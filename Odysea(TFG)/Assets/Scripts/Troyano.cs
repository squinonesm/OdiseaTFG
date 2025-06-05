using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Troyano : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float walkStopRate = 0.05f;
    [SerializeField] private TroyanoDeteccion attackZone;
    [SerializeField] private bool _hasTarget = false;
    TroyanoDaño daño;

    Rigidbody2D rb2D;
    Animator animator;

    public enum WalkableDirection { Right, Left}

    
    private WalkableDirection _walkDirection;
    private Vector2 walkDirectionVector = Vector2.right;

    public WalkableDirection WalkDirection
    {
        get { return _walkDirection; }
        set
        {
            if (_walkDirection != value)
            {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

                if (value == WalkableDirection.Right)
                {
                    walkDirectionVector = Vector2.right;
                }
                else if (value == WalkableDirection.Left)
                {
                    walkDirectionVector = Vector2.left;
                }
            }
            _walkDirection = value;
        }
    }

    private void FlipDirection()
    {
        if (WalkDirection == WalkableDirection.Right)
        {
            WalkDirection = WalkableDirection.Left;
        }else if (WalkDirection == WalkableDirection.Left)
        {
            WalkDirection = WalkableDirection.Right;
        }
    }
     
    
    public bool HasTarget
    {
        get { return _hasTarget; }
        private set
        {
            _hasTarget = value;
            animator.SetBool("hasTarget", value);
        }
    }

    public bool CanMove
    {
        get
        {
            return animator.GetBool("canMove");
        }
    }

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        daño = GetComponent<TroyanoDaño>();
    }

    public float AttackCooldown
    {
        get
        {
            return animator.GetFloat("attackCooldown");
        }
        private set
        {
            animator.SetFloat("attackCooldown", Mathf.Max(value,0));
        }
    }

    private void Update()
    {

        HasTarget = attackZone.detectedColliders.Count > 0;

        if (AttackCooldown > 0)
        {
           AttackCooldown -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (CanMove)
        {
            rb2D.velocity = new Vector2(walkSpeed * walkDirectionVector.x, rb2D.velocity.y);
        }
        else
        {
            rb2D.velocity = new Vector2(Mathf.Lerp(rb2D.velocity.x, 0, walkStopRate), rb2D.velocity.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si choca contra cualquier cosa excepto el jugador, da la vuelta
        if (!collision.collider.CompareTag("Player") && !collision.collider.CompareTag("Suelo"))
        {
            FlipDirection();
        }
    }

}
