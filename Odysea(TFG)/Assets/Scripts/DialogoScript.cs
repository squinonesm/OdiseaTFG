using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogoScript : MonoBehaviour
{
    [Header("Componentes UI")]
    [SerializeField] GameObject objetoDialogo;
    [SerializeField] TextMeshProUGUI textoConversacion;
    [SerializeField] TextMeshProUGUI nombreTexto;
    [SerializeField] Image imagenNarrador;
    [SerializeField] Button siguienteLineaBoton;

    [Header("Contenido del diálogo")]
    [TextArea][SerializeField] string[] lineasDialogo;
    [SerializeField] string[] nombresPorLinea;
    [SerializeField] int[] personajePorLinea;
    [SerializeField] Sprite[] imagenesCuadroDialogo;  // Array de sprites para los personajes

    [Header("Opcionales")]
    [SerializeField] bool seDebeMover;
    [SerializeField] bool esDialogoBoss;

    public OdiseoPlayer jugador;

    private int indiceConversacion = 0;
    private bool dialogoActivo = false;

    void Start()
    {
        siguienteLineaBoton.onClick.AddListener(SiguienteLinea);
        objetoDialogo.SetActive(false);
    }

    public void ComenzarConversacion()
    {
        if (lineasDialogo.Length == 0) return;

        dialogoActivo = true;
        indiceConversacion = 0;
        objetoDialogo.SetActive(true);
        MostrarLinea();

        if (jugador != null)
            jugador.enabled = false;  // Bloquear movimiento jugador
    }

    public void SiguienteLinea()
    {
        indiceConversacion++;

        if (indiceConversacion >= lineasDialogo.Length)
        {
            TerminarConversacion();
        }
        else
        {
            MostrarLinea();
        }
    }

    void MostrarLinea()
    {
        textoConversacion.text = lineasDialogo[indiceConversacion];
        nombreTexto.text = nombresPorLinea[indiceConversacion];
        CrearSprite(personajePorLinea[indiceConversacion]);
    }

    void CrearSprite(int indicePersonaje)
    {
        if (indicePersonaje < 0 || indicePersonaje >= imagenesCuadroDialogo.Length) return;

        imagenNarrador.sprite = imagenesCuadroDialogo[indicePersonaje];
    }

    void TerminarConversacion()
    {
        dialogoActivo = false;
        objetoDialogo.SetActive(false);
        if (jugador != null)
            jugador.enabled = true;   // Desbloquear movimiento jugador
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !dialogoActivo)
        {
            Debug.Log("Odiseo entró en el trigger de Zeus");
            ComenzarConversacion();
            GetComponent<Collider2D>().enabled = false; // evitar que se active de nuevo
        }
    }
}
