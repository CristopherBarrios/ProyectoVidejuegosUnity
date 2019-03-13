using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void Salir()
    {
        Application.Quit();
        Debug.Log("Te saliste del juego vos");
    }
    public void CargaNivel(string pNombreNivel)
    {
        SceneManager.LoadScene(pNombreNivel);
    }
}
