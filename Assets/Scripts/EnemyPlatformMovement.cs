using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlatformMovement : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Transform groundController;
    [SerializeField] private float distancia;
    [SerializeField] private bool movingRight;
    private Rigidbody2D enemyRB;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D informacionSuelo = Physics2D.Raycast(groundController.position, Vector2.down, distancia);
        enemyRB.velocity = new Vector2(velocidad, enemyRB.velocity.y);

        if (informacionSuelo == false)
        {
            Girar();
        }
    }

    private void Girar()
    {
        movingRight = !movingRight;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(groundController.transform.position, groundController.transform.position + Vector3.down * distancia);
    }
}
