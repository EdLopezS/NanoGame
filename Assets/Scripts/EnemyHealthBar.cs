using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    private HealthBar healthBar; // Referencia al script HealthBar

    void Start()
    {
        healthBar = GetComponentInChildren<HealthBar>(); // Obtener referencia al componente HealthBar
    }

    public void SetMaxHealth(float maxHealth)
    {
        healthBar.SetMaxHealth(maxHealth); // Configurar la salud máxima en la barra de vida
    }

    public void SetHealth(float currentHealth)
    {
        healthBar.SetHealth(currentHealth); // Actualizar la salud actual en la barra de vida
    }
}
