using UnityEngine;

public class ButtonsController : Controller
{
    public GameObject objetoLevels;
    public GameObject objetoCustomice;
    public GameObject objetoStats;
    public GameObject SoundOnButtom;
    public GameObject SoundOffButtom;
    private bool objetoActivo = false;
    private bool objetoCustomiceActivo = false;
    private bool objetostats = false;
    private bool _objetoOnSound = true;
    private bool _objetoOffSound = false;

    private bool isMuted = false;

    public override Vector3 GetInputs()
    {
        throw new System.NotImplementedException();
    }

    public void SelectLevels()
    {
        objetoActivo = true; // Cambia el estado del objeto
        objetoLevels.SetActive(objetoActivo); // Activa o desactiva el GameObject
    }
    public void XSelectLevels()
    {
        objetoActivo = false;
        objetostats = false;
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
    public void DeleteStats()
    {
        objetostats = true;
        objetoStats.SetActive(objetostats);
    }

    public void MuteSounds()
    {
        _objetoOnSound = false;
        _objetoOffSound = true;
        SoundOnButtom.SetActive(_objetoOnSound);
        SoundOffButtom.SetActive(_objetoOffSound);
        isMuted = true;
        AudioListener.volume = 0f; // Establecer el volumen a 0 para mutear
    }

    public void UnmuteSounds()
    {
        _objetoOnSound = true;
        _objetoOffSound = false;
        SoundOnButtom.SetActive(_objetoOnSound);
        SoundOffButtom.SetActive(_objetoOffSound);
        isMuted = false;
        AudioListener.volume = 1f; // Establecer el volumen a 1 para reanudar
    }

    public void Warning()
    {

    }
}
