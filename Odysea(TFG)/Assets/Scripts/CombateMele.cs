using UnityEngine;

public class Combatecac : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;  
    [SerializeField] private float radioGolpe;            
    [SerializeField] private float da�oGolpe;             
    [SerializeField] private float tiempoEntreAtaques;
    [SerializeField] private float tiempoSiguienteAtaque;

    private Animator animator;

    private void Start() 
    { 
        animator = GetComponent<Animator>();    
    }

    private void Update()
    {
        if(tiempoSiguienteAtaque > 0)
        {
            tiempoSiguienteAtaque -= Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Space) && tiempoSiguienteAtaque <= 0)
        {
            Golpe();
            tiempoSiguienteAtaque = tiempoEntreAtaques;
        }     
    }

    private void Golpe()
    {

        animator.SetTrigger("Golpe");

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position,radioGolpe);

        foreach (Collider2D colisionador in objetos)
        {
            Polyphemus poli = colisionador.GetComponent<Polyphemus>();
            if (poli != null)
            {
                poli.TomarDa�o(da�oGolpe);
            }

            TroyanoDa�o troyano = colisionador.GetComponent<TroyanoDa�o>();
            if (troyano != null)
            {
                troyano.Hit(da�oGolpe);
            }
        }

    }

    // Visualizar el �rea de ataque en el editor
    private void OnDrawGizmos()
    {
        if (controladorGolpe != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
        }
    }
}