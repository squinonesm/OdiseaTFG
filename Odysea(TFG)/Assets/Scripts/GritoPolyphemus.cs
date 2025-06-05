using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GritoPolyphemus : MonoBehaviour
{
    private AudioSource audioSource;
    private bool yaReproducido = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !yaReproducido)
        {
            audioSource.Play();
            yaReproducido = true; 

          
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
