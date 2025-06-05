using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TroyanoDaño : MonoBehaviour
{
    [SerializeField] 
    private float _vidaMaxima = 100;
    private bool _isAlive = true;

    Animator animator;

    public float VidaMaxima
    {
        get { return _vidaMaxima; }
        set { _vidaMaxima = value; }
    }

    private float _vida;


    public float Vida
    {
        get { return _vida; }
        set 
        {
            _vida = value; 

            if(_vida <= 0)
            {
                IsAlive = false;
                StartCoroutine(DesaparecerDespuesDeTiempo(1.5f));
            }

        }
    }
    private IEnumerator DesaparecerDespuesDeTiempo(float segundos)
    {
        yield return new WaitForSeconds(segundos);
        Destroy(gameObject);
    }
    public bool IsAlive
    {
        get
        {
            return _isAlive;
        }
        set
        {
            _isAlive = value;
            animator.SetBool("isAlive", value);
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        _vida = _vidaMaxima;
    }

    public bool Hit(float daño)
    {
        if (IsAlive)
        {
            Debug.Log("recibido");
           Vida -= daño;
           GetComponent<FlashEffect>().Flash();
           return true;
        }

        return false;
    }

}
