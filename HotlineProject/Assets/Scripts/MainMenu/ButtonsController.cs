using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsController : Controller
{
    public EscenasEnum nuevaEscena; // Enum que va a representar a las escenas
    public GameObject objetoLevels;
    public GameObject objetoCustomice;
    private bool objetoActivo = false;
    private bool objetoCustomiceActivo = false;
    public override Vector3 GetInputs()
    {
        throw new System.NotImplementedException();
    }

    public void StartLevel()
    {
        string nombreEscena = nuevaEscena.ToString(); // Esto lo convierte a String que si bien no le estoy dando utilidad ahora
        SceneManager.LoadScene(0);                    // Va a servir para el selector de niveles
    }
    public void SelectLevels()
    {
        objetoActivo = true; // Cambia el estado del objeto
        objetoLevels.SetActive(objetoActivo); // Activa o desactiva el GameObject
    }
    public void XSelectLevels()
    {
        objetoActivo = false;
        objetoLevels.SetActive(objetoActivo);
    }
    public void Customice()
    {
        objetoCustomiceActivo =! objetoCustomiceActivo;
        objetoCustomice.SetActive(objetoCustomiceActivo);
    }

    public enum EscenasEnum
    {
        SampleScene
    }
}
