using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicionEscena : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private AnimationClip Escaleras;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void IniciarTransicion()
    {
        StartCoroutine(CambiarEscena());
    }

    private IEnumerator CambiarEscena()
    {
        animator.SetTrigger("Iniciar");
        yield return new WaitForSeconds(Escaleras.length);
        SceneManager.LoadScene(1);
    }
}