using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float velocidad;
    public int daño;

    private Rigidbody2D rb;

    void Start()
    {
        // Obtener o agregar el componente Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
            rb.isKinematic = true; // Hacer que el Rigidbody2D sea cinemático para que no sea afectado por la gravedad
        }
    }

    void Update()
    {
        // Si el Rigidbody2D está presente, mover la bala
        if (rb != null)
        {
            rb.velocity = transform.right * velocidad;
        }
        else
        {
            // Si no se pudo obtener o agregar el Rigidbody2D, mover la bala sin él
            transform.Translate(Time.deltaTime * velocidad * Vector2.right);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerCombat playerHealth))
        {
            playerHealth.TomarDaño(daño);
            Destroy(gameObject);
        }
    }
}
