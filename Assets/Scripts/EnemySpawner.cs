using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    [SerializeField] private Transform[] puntos;
    [SerializeField] private GameObject[] enemigos;
    [SerializeField] private GameObject barraVidaPrefab; // Prefab de la barra de vida
    [SerializeField] private float tiempoEnemigos;
    private float tiempoSiguienteEnemigo;

    // Start is called before the first frame update
    void Start()
    {
        maxX = puntos.Max(punto => punto.position.x);
        minX = puntos.Min(punto => punto.position.x);
        maxY = puntos.Max(punto => punto.position.y);
        minY = puntos.Min(punto => punto.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        tiempoSiguienteEnemigo += Time.deltaTime;

        if (tiempoSiguienteEnemigo >= tiempoEnemigos)
        {
            tiempoSiguienteEnemigo = 0;
            CrearEnemigo();
        }
    }

    private void CrearEnemigo()
    {
        int numeroEnemigo = UnityEngine.Random.Range(0, enemigos.Length);
        Vector2 posicionAleatoria = new Vector2(UnityEngine.Random.Range(minX, maxX), UnityEngine.Random.Range(minY, maxY));

        GameObject nuevoEnemigo = Instantiate(enemigos[numeroEnemigo], posicionAleatoria, Quaternion.identity);

        // Instanciar la barra de vida como hijo del enemigo recién creado
        GameObject nuevaBarraVida = Instantiate(barraVidaPrefab, nuevoEnemigo.transform);

        // Ajustar la posición relativa local de la barra de vida para que esté arriba del enemigo
        nuevaBarraVida.transform.localPosition = new Vector3(0f, 1f, 0f); // Cambiar 1f al valor deseado para ajustar la altura

        // Obtener la referencia al componente EnemyHealthBar y configurar la salud máxima
        EnemyHealthBar enemyHealthBar = nuevaBarraVida.GetComponentInChildren<EnemyHealthBar>();
        if (enemyHealthBar != null)
        {
            enemyHealthBar.SetMaxHealth(nuevoEnemigo.GetComponent<Enemy>().maxHealth);
        }
    }



}



