using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marcador : MonoBehaviour
{
    public static int scoreValue = 0;
    Text marcador;

    // Start is called before the first frame update
    void Start()
    {
        
        marcador = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        marcador.text = "Score:  " + scoreValue; 
       
    }
}
