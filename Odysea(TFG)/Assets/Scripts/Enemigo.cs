using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Enemigo : MonoBehaviour
{

    [SerializeField] private float vida;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;

        if (vida <= 0)
        {
            Muerte();
        }
    }

    public void Muerte()
    {
        animator.SetTrigger("Muerte");
    }
}
