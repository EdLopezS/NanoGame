using UnityEngine;

public class EnemyShootB3 : MonoBehaviour
{
    public Transform[] controladoresDisparo;
    public float distanciaLinea;
    public LayerMask capaJugador;
    public bool jugadorEnRango;
    public float tiempoEsperaDisparo;
    public float tiempoEntreDisparos;
    public GameObject balaEnemigo;

    void Update()
    {
        // Calcular la direcci�n de las diagonales para los raycasts
        Vector2[] direccionesDiagonales = {
            new Vector2(transform.right.x, transform.up.y).normalized,
            new Vector2(transform.right.x, -transform.up.y).normalized,
            new Vector2(-transform.right.x, transform.up.y).normalized,
            new Vector2(-transform.right.x, -transform.up.y).normalized
        };

        // Verificar si el jugador est� en rango para cada raycast diagonal
        foreach (Transform controladorDisparo in controladoresDisparo)
        {
            for (int i = 0; i < direccionesDiagonales.Length; i++)
            {
                jugadorEnRango = Physics2D.Raycast(controladorDisparo.position, direccionesDiagonales[i], distanciaLinea, capaJugador);

                if (jugadorEnRango)
                {
                    if (Time.time > tiempoEntreDisparos + tiempoEsperaDisparo)
                    {
                        tiempoEntreDisparos = Time.time;
                        Disparar(controladorDisparo, direccionesDiagonales[i]);
                    }
                }
            }
        }
    }

    public void Disparar(Transform controladorDisparo, Vector2 direccionDisparo)
    {
        // Calcular el �ngulo de rotaci�n a partir de la direcci�n del raycast
        float angulo = Mathf.Atan2(direccionDisparo.y, direccionDisparo.x) * Mathf.Rad2Deg;
        // Crear la bala con la direcci�n de disparo correcta
        GameObject nuevaBala = Instantiate(balaEnemigo, controladorDisparo.position, Quaternion.AngleAxis(angulo, Vector3.forward));
        // Aplicar fuerza a la bala en la direcci�n de disparo
        nuevaBala.GetComponent<Rigidbody2D>().velocity = direccionDisparo * 10f;
    }

    private void OnDrawGizmos()
    {
        // Dibujar los raycasts en las direcciones diagonales para cada controlador de disparo
        Gizmos.color = Color.green;
        Vector2[] direccionesDiagonales = {
            new Vector2(transform.right.x, transform.up.y).normalized,
            new Vector2(transform.right.x, -transform.up.y).normalized,
            new Vector2(-transform.right.x, transform.up.y).normalized,
            new Vector2(-transform.right.x, -transform.up.y).normalized
        };

        foreach (Transform controladorDisparo in controladoresDisparo)
        {
            foreach (Vector2 direccion in direccionesDiagonales)
            {
                Gizmos.DrawLine(controladorDisparo.position, controladorDisparo.position + (Vector3)direccion * distanciaLinea);
            }
        }
    }
}
