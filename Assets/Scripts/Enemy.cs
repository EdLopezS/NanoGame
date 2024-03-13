using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private GameObject efectoMuerte;
    [SerializeField] private GameObject efecto;

    public float maxHealth = 10f; // Salud máxima del enemigo
    private float currentHealth; // Salud actual del enemigo

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    public void TomarDaño(float daño)
    {
        currentHealth -= daño;
        if (currentHealth <= 0)
        {
            Muerte();
        }
    }

    public void Muerte()
    {
        Instantiate(efectoMuerte, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.GetContact(0).normal.y <= -0.9)
            {
                animator.SetTrigger("Golpe");
                other.gameObject.GetComponent<Player>().Rebote();
            }
            else
            {
                other.gameObject.GetComponent<PlayerCombat>().TomarDaño(30, other.GetContact(0).normal);
            }
        }
    }

    public void Hit()
    {
        Instantiate(efectoMuerte, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
