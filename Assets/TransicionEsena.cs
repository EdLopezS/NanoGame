using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicionEsena : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private AnimationClip animacionFinal;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(CambiarEscena());
        }
    }

    IEnumerator CambiarEscena()
    {
        animator.SetTrigger("Iniciar");
        yield return new WaitForSeconds(animacionFinal.length);
        SceneManager.LoadScene(1);
    }
}
