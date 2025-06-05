using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class RecargarEscena
{
    
    public static void RecargarNivel()
    {
        Scene escena = SceneManager.GetActiveScene();
        SceneManager.LoadScene(escena.name);
    }

    
}
