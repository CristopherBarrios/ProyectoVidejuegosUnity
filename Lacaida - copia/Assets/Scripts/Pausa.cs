using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pausa : MonoBehaviour { 

    bool active;
    Canvas canvas;
    public AudioClip pausa;
   
    AudioSource Tenesonido;

    // Start is called before the first frame update
    void Start()
    {


        canvas = GetComponent<Canvas>();
        Tenesonido = GetComponent<AudioSource>();


        canvas.enabled = false;

        Time.timeScale = (active) ? 1 : 1f;

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
         
            Tenesonido.clip = pausa;
            Tenesonido.Play();
            active = !active;
            canvas.enabled = active;
            Time.timeScale = (active) ? 0 : 1f;
            
        }
    }
   
    public void CargaNivel(string pNombreNivel)
    {
        SceneManager.LoadScene(pNombreNivel);
    }
    public void Regresarrrr()
    {
        canvas.enabled = false;
        Time.timeScale = (active) ? 1 : 1f;
    }
}
