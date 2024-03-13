using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoControl : MonoBehaviour
{
   private Animator animator;

   private void Start()
   {
    animator = GetComponent<Animator>();
   }


   private void OnTriggerEnter2D(Collider2D other)
   {
    if(other.CompareTag("Player"))
    {
        animator.SetTrigger("Activar");
        ControladorJuego.Instance.UltimoPuntoControl(gameObject);
    }
   }
}
