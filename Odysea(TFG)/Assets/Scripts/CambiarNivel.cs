using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarNivel : MonoBehaviour
{

    [SerializeField] private TransicionEscena transicion;

    public GameObject panel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        int siguienteEscena = escenaActual + 1;

        if (siguienteEscena < SceneManager.sceneCountInBuildSettings)
        {
            if (siguienteEscena == 1)
            {
                panel.SetActive(true);
                transicion.IniciarTransicion();
            }
            else
            {
                SceneManager.LoadScene(siguienteEscena);
            }
        }
    }
}