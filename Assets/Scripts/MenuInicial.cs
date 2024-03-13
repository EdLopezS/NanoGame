using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInicial : MonoBehaviour
{
    public Slider slider; // Referencia al objeto Slider en la escena

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CargarEscena("Level1");
        }
    }

    public void Jugar()
    {
        CargarEscena(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Salir()
    {
        UnityEngine.Application.Quit(); // Especifica el namespace UnityEngine
    }

    void CargarEscena(int indiceEscena)
    {
        StartCoroutine(CargarAsync(indiceEscena));
    }

    void CargarEscena(string nombreEscena)
    {
        StartCoroutine(CargarAsync(nombreEscena));
    }

    IEnumerator CargarAsync(int indiceEscena)
    {
        UnityEngine.AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(indiceEscena); // Especifica el namespace UnityEngine

        while (!asyncOperation.isDone)
        {
            float progreso = Mathf.Clamp01(asyncOperation.progress / 0.9f); // Progreso de carga normalizado entre 0 y 1
            slider.value = progreso; // Actualizar el valor del Slider
            yield return null;
        }
    }

    IEnumerator CargarAsync(string nombreEscena)
    {
        UnityEngine.AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(nombreEscena); // Especifica el namespace UnityEngine

        while (!asyncOperation.isDone)
        {
            float progreso = Mathf.Clamp01(asyncOperation.progress / 0.9f); // Progreso de carga normalizado entre 0 y 1
            slider.value = progreso; // Actualizar el valor del Slider
            yield return null;
        }
    }
}

