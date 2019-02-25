using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform objetivo;
    public float suavisado = 5f;

    Vector3 desface;

    void Start()
    {
        desface = transform.position - objetivo.position; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 posicionObjetivo = objetivo.position + desface;
        transform.position = Vector3.Lerp(transform.position, posicionObjetivo, suavisado * Time.deltaTime);
    }
}
