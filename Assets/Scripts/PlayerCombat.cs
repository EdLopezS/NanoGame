using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private float vida;
    private Player player;
    [SerializeField] private float timepoPerdidaControl; 
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();
    }

    public void TomarDa�o(float da�o)
    {
        vida -= da�o;

        if (vida <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void TomarDa�o(float da�o, Vector2 posicion)
    {
        vida -= da�o;
        animator.SetTrigger("Golpe");
        StartCoroutine(PerderControl());
        StartCoroutine(DesactivarColision());
        //Perder control
        player.Retroceso(posicion);
    }

    private IEnumerator DesactivarColision()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        yield return new WaitForSeconds(timepoPerdidaControl);
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }

    private IEnumerator PerderControl()
    {
        player.sePuedeMover = false;
        yield return new WaitForSeconds(timepoPerdidaControl);
        player.sePuedeMover = true;
    }
}
