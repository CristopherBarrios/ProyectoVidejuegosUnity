using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioGrande : MonoBehaviour
{
    public GameObject MarioGrandeje;
    public GameObject MarioPeque;
    public GameObject MarioPo;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "muerte")
        {
            MarioGrandeje.SetActive(false);
            MarioPeque.SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "hongo")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "estrella")
        {
            MarioPo.SetActive(true);
            MarioGrandeje.SetActive(false);
            Destroy(other.gameObject);
        }
    }
}
