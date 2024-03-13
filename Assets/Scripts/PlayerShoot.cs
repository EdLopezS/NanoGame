using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject bala;
    private EntradasMovimiento entradasMovimiento;

    [SerializeField] private float tiempoEntreDisparos;
    private float cooldown;
    private void Awake()
    {
        entradasMovimiento = new EntradasMovimiento();
    }

    private void OnEnable()
    {
        entradasMovimiento.Enable();
    }

    private void OnDisable()
    {
        entradasMovimiento.Disable();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire2") && Time.time >= cooldown){

            Shoot();
            cooldown = Time.time + tiempoEntreDisparos;
        }
    }

    public void Shoot()
    {
        Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
    }
}
