using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider; // Referencia al componente Slider de Unity

    private void Start()
    {
        slider = GetComponent<Slider>(); // Obtener la referencia al componente Slider
    }

    public void SetMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth; // Establecer el valor máximo del Slider como la salud máxima
        slider.value = maxHealth; // Inicializar el valor actual del Slider como la salud máxima
    }

    public void SetHealth(float currentHealth)
    {
        slider.value = currentHealth; // Actualizar el
    }
}
