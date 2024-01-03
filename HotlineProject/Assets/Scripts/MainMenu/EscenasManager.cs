using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenasManager : MonoBehaviour
{
    public EscenasEnum nuevaEscena;
    public StaminaSistem staminaSistem;

    private void Awake() {
        staminaSistem = FindObjectOfType<StaminaSistem>();
    }

    public void StartLevel()
    {
        if(staminaSistem.currentstamina >= 1)
        {
        string nombreEscena = nuevaEscena.ToString(); // Convierte el valor del enum a una cadena (string).
        SceneManager.LoadScene(nombreEscena);         // Llama a la escena por el nombre
        //staminaSistem.RestarVida();
        }

        else if(staminaSistem.currentstamina == 0)
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
        Level5,
        Level6,
        Level7,
    }
}
