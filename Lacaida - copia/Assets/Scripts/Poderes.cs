using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Poderes : MonoBehaviour
{
    public string escena;
    

    public GameObject MarioGrandeje;
    public GameObject MarioPeque;
    public GameObject MarioPo;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "muerte")
        {
            SceneManager.LoadScene(escena);
        }
        if(other.gameObject.tag == "hongo")
        {
            MarioGrandeje.SetActive(true);
            MarioPeque.SetActive(false);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "estrella")
        {
            MarioPo.SetActive(true);
            MarioPeque.SetActive(false);
            Destroy(other.gameObject);
        }
    }

}