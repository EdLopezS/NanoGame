using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

public class ControladorDatosJuego : MonoBehaviour
{
    public GameObject jugador;
    public string archivoDeGuardado;
    public DatosJuego datosJuego = new DatosJuego();

    private void Awake()
    {
        archivoDeGuardado = UnityEngine.Application.persistentDataPath + "/datosJuego.json";

        jugador = GameObject.FindGameObjectWithTag("Player");

        CargarDatos();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            CargarDatos();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            GuardarDatos();
        }
    }

    private void CargarDatos()
    {
        if (File.Exists(archivoDeGuardado))
        {
            string contenido = File.ReadAllText(archivoDeGuardado);
            datosJuego = JsonUtility.FromJson<DatosJuego>(contenido);
            UnityEngine.Debug.Log("Posicion Jugador : " + datosJuego.posicion);

            jugador.transform.position = datosJuego.posicion;
        }
        else
        {
            UnityEngine.Debug.Log("El archivo no existe");

        }
    }

    private void GuardarDatos()
    {
        DatosJuego nuevosDatos = new DatosJuego()
        {
            posicion = jugador.transform.position
        };

        string cadenaJSON = JsonUtility.ToJson(nuevosDatos);
        File.WriteAllText(archivoDeGuardado, cadenaJSON);

        UnityEngine.Debug.Log("Archivo Guardado");
    }
}
