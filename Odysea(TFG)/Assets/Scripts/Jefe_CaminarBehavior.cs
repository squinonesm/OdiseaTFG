using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jefe_CaminarBehaviour : StateMachineBehaviour
{
    private Polyphemus jefe;
    private Rigidbody2D rb2D;

    [SerializeField] private float velocidadMovimiento = 2f; // o lo que prefieras

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jefe = animator.GetComponent<Polyphemus>();
        rb2D = jefe.rb2D;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jefe.MirarJugador();

        // Movimiento hacia el jugador según la escala (izquierda o derecha)
        float direccion = Mathf.Sign(jefe.transform.localScale.x);
        rb2D.velocity = new Vector2(direccion * velocidadMovimiento, rb2D.velocity.y);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb2D.velocity = new Vector2(0, rb2D.velocity.y);
    }
}
