using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioP : MonoBehaviour
{
    public GameObject MarioGrandeje;
    public GameObject MarioPeque;
    public GameObject MarioPo;
    public int contador = 5;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "muerte")
        {
            contador = contador - 1;
            Destroy(other.gameObject);
            if (contador == 0)
            {
                MarioPo.SetActive(false);
                MarioPeque.SetActive(true);
                contador = 5;
            }
            
        }
        if (other.gameObject.tag == "hongo")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "estrella")
        {
            Destroy(other.gameObject);
        }
    }
}
