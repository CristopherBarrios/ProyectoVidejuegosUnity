using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    public float speed = 0.1f;
    public float x;
    public float lugar;

    public int contador = 0;
    public Text puntuacion;
    public string escena;
    public string NivelNuevo;

    public AudioClip MammaMia;
    AudioSource Tenesonido;

    void Start()
    {
        Tenesonido = GetComponent<AudioSource>();
        Tenesonido.clip = MammaMia;
        Tenesonido.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float Mover = Input.GetAxis("Horizontal");
        if (Mover > 0)
        {
            x = transform.position.x + (Mover * speed);
            transform.position = new Vector3(x, transform.position.y, 0);
            transform.localScale = new Vector3(-8f, 8f, 8f);
            x = lugar;
        }
        if (Mover < 0)
        {
            x = transform.position.x + (Mover * speed);
            transform.position = new Vector3(x, transform.position.y, 0);
            transform.localScale = new Vector3(8f, 8f, 8f);
            x = lugar;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "muerte")
        {
            SceneManager.LoadScene(escena);
        }
        if (other.gameObject.tag == "punto")
        {
            Destroy(other.gameObject);
            contador = contador + 1;
            puntuacion.text = "" + contador;
        }
        if (other.gameObject.tag == "NuevoNivel")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(NivelNuevo);
        }
    }
    }
