using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroyanoDeteccion : MonoBehaviour
{  
    public List<Collider2D> detectedColliders = new List<Collider2D>();
    Collider2D col;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    detectedColliders.Add(collision);
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    detectedColliders.Remove(collision);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !detectedColliders.Contains(collision))
            detectedColliders.Add(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            detectedColliders.Remove(collision);
    }


}
