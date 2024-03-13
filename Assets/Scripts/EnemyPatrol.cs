using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] waypoints; // Array de puntos de patrulla
    public float moveSpeed = 3f; // Velocidad de movimiento del enemigo

    private int currentWaypointIndex = 0; // Índice del punto de patrulla actual

    void Update()
    {
        // Verificar si hay puntos de patrulla asignados
        if (waypoints.Length == 0)
        {
            UnityEngine.Debug.LogWarning("No se han asignado puntos de patrulla.");
            return;
        }

        // Mover al enemigo hacia el punto de patrulla actual
        MoveTowardsWaypoint();
    }

    void MoveTowardsWaypoint()
    {
        // Calcular la dirección hacia el punto de patrulla actual
        Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
        direction.y = 0f; // Ignorar la componente Y (altura)

        // Mover al enemigo en la dirección del punto de patrulla actual
        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);

        // Si el enemigo está lo suficientemente cerca del punto de patrulla actual, cambiar al siguiente punto
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) <= 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; // Avanzar al siguiente punto de patrulla
        }
    }
}
