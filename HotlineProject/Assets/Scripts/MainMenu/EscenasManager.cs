using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenasManager : StaminaLevel
{
    public EscenasEnum nuevaEscena;

    public void StartLevel()
    {
        if(vidas >= 1)
        {
        string nombreEscena = nuevaEscena.ToString(); // Convierte el valor del enum a una cadena (string).
        SceneManager.LoadScene(nombreEscena);         // Llama a la escena por el nombre
        RestarVida();
        }

        else if(vidas == 0)
        {
            Debug.Log("No tienes Vida");
        }
    }

    public void ReturnToMaimMenu()
    {
        string nombreEscena = nuevaEscena.ToString();
        SceneManager.LoadScene(nombreEscena);
    }

    public enum EscenasEnum
    {
        MainMenu,
        LevelTutorial,
        Level1,
        Level2,
    }
}
