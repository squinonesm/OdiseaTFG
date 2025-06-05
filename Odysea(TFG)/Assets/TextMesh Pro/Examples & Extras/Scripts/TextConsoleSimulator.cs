using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Necesario para el botón
using UnityEngine.SceneManagement; // Necesario para cambiar de escena
using TMPro;

public class SimuladorTextoConsola : MonoBehaviour
{
    [Header("Configuración del texto")]
    public float velocidadEscritura = 0.05f; // Velocidad de tipeo (en segundos)
    public bool reproducirAlInicio = true;   // ¿Empieza automáticamente al cargar la escena?

    [Header("Botón para continuar")]
    public Button botonContinuar;            // Asigná un botón desde el Inspector

    private TMP_Text textoTMP;
    private bool yaReproducido = false;

    void Awake()
    {
        textoTMP = GetComponent<TMP_Text>();
    }

    void Start()
    {
        if (reproducirAlInicio && !yaReproducido)
        {
            StartCoroutine(RevelarCaracteres());
        }

        if (botonContinuar != null)
        {
            botonContinuar.onClick.AddListener(CargarEscenaInicial); // Asignar acción al botón
            botonContinuar.gameObject.SetActive(false); // Ocultar botón al inicio
        }
    }

    public void ReproducirEfecto()
    {
        if (!yaReproducido)
        {
            StartCoroutine(RevelarCaracteres());
        }
    }

    IEnumerator RevelarCaracteres()
    {
        yaReproducido = true;

        textoTMP.ForceMeshUpdate();
        TMP_TextInfo infoTexto = textoTMP.textInfo;

        int totalCaracteres = infoTexto.characterCount;
        int visibles = 0;

        while (visibles <= totalCaracteres)
        {
            textoTMP.maxVisibleCharacters = visibles;
            visibles++;
            yield return new WaitForSeconds(velocidadEscritura);
        }

        // Mostrar el botón cuando termina de escribir
        if (botonContinuar != null)
        {
            botonContinuar.gameObject.SetActive(true);
        }
    }

    public void CargarEscenaInicial()
    {
        SceneManager.LoadScene(0);
    }
}
