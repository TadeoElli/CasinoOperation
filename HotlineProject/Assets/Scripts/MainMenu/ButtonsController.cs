using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsController : Controller
{
    public EscenasEnum nuevaEscena; // Enum que va a representar a las escenas
    public GameObject objetoLevels;
    public GameObject objetoCustomice;
    public GameObject objetoHowToPlay;
    public GameObject objetoStats;
    private bool objetoActivo = false;
    private bool objetoCustomiceActivo = false;
    private bool objetoInstrucciones = false;
    private bool objetostats = false;
    public override Vector3 GetInputs()
    {
        throw new System.NotImplementedException();
    }

    public void StartLevel()
    {
        string nombreEscena = nuevaEscena.ToString(); // Esto lo convierte a String que si bien no le estoy dando utilidad ahora
        SceneManager.LoadScene(1);                    // Va a servir para el selector de niveles
    }
    public void SelectLevels()
    {
        objetoActivo = true; // Cambia el estado del objeto
        objetoLevels.SetActive(objetoActivo); // Activa o desactiva el GameObject
    }
    public void XSelectLevels()
    {
        objetoActivo = false;
        objetoInstrucciones = false;
        objetostats = false;
        objetoHowToPlay.SetActive(objetoInstrucciones);
        objetoLevels.SetActive(objetoActivo);
        objetoStats.SetActive(objetostats);
    }
    public void OkButtom()
    {
        objetoCustomiceActivo = false;
        objetoCustomice.SetActive(objetoCustomiceActivo);
    }
    public void Customice()
    {
        objetoCustomiceActivo = true;
        objetoCustomice.SetActive(objetoCustomiceActivo);
    }
    public void HowToPlay()
    {
        objetoInstrucciones = true;
        objetoHowToPlay.SetActive(objetoInstrucciones);
    }
    public void DeleteStats()
    {
        objetostats = true;
        objetoStats.SetActive(objetostats);
    }

    public enum EscenasEnum
    {
        SampleScene = 1
    }
}
