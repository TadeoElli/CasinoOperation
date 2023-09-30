using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenasManager : MonoBehaviour
{
    public EscenasEnum nuevaEscena;

    public void StartLevel()
    {
        string nombreEscena = nuevaEscena.ToString(); // Convierte el valor del enum a una cadena (string).
        SceneManager.LoadScene(nombreEscena);         // Llama a la escena por el nombre
    }

    public enum EscenasEnum
    {
        MainMenu,
        Level1,
        Level2,
    }
}
