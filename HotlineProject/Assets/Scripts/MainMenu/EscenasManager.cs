using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenasManager : MonoBehaviour
{
    public EscenasEnum nuevaEscena;
    public StaminaLevel staminaLevel;

    private void Awake() {
        staminaLevel = FindObjectOfType<StaminaLevel>();
    }

    public void StartLevel()
    {
        if(staminaLevel.vidas >= 1)
        {
        string nombreEscena = nuevaEscena.ToString(); // Convierte el valor del enum a una cadena (string).
        SceneManager.LoadScene(nombreEscena);         // Llama a la escena por el nombre
        staminaLevel.RestarVida();
        }

        else if(staminaLevel.vidas == 0)
        {
            Debug.Log("No tienes Vida");
        }
    }

    public void StartTutorial()
    {
        string nombreEscena = nuevaEscena.ToString();
        SceneManager.LoadScene(nombreEscena);
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
        Level3,
        Level4,
    }
}
