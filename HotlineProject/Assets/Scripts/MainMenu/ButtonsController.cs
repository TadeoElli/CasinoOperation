using UnityEngine;
using UnityEngine.UI;

public class ButtonsController : Controller
{
    public GameObject objetoLevels;
    public GameObject objetoCustomize;
    public GameObject objetoStats;
    public GameObject SoundOnButton;
    public GameObject SoundOffButton;
    public GameObject quitWarningCanvas;
    public Button confirmQuitButton;
    public Button cancelQuitButton;

    private bool objetoLevelsActive = false;
    private bool objetoCustomizeActive = false;
    private bool objetoStatsActive = false;
    private bool isSoundOn = true;

    private void Start()
    {
        quitWarningCanvas.SetActive(false);

        confirmQuitButton.onClick.AddListener(ConfirmQuit);
        cancelQuitButton.onClick.AddListener(CancelQuit);
    }

    public override Vector3 GetInputs()
    {
        throw new System.NotImplementedException();
    }

    public void SelectLevels()
    {
        objetoLevelsActive = true;
        objetoCustomizeActive = false;
        objetoStatsActive = false;

        objetoLevels.SetActive(objetoLevelsActive);
        objetoCustomize.SetActive(objetoCustomizeActive);
        objetoStats.SetActive(objetoStatsActive);
    }

    public void XSelectLevels()
    {
        objetoLevelsActive = false;
        objetoStatsActive = false;

        objetoLevels.SetActive(objetoLevelsActive);
        objetoStats.SetActive(objetoStatsActive);
    }

    public void OkButton()
    {
        objetoCustomizeActive = false;
        objetoCustomize.SetActive(objetoCustomizeActive);
    }

    public void Customize()
    {
        objetoCustomizeActive = true;
        objetoCustomize.SetActive(objetoCustomizeActive);
    }

    public void DeleteStats()
    {
        objetoStatsActive = true;
        objetoStats.SetActive(objetoStatsActive);
    }

    public void MuteSounds()
    {
        isSoundOn = false;
        SoundOnButton.SetActive(isSoundOn);
        SoundOffButton.SetActive(!isSoundOn);
        AudioListener.volume = 0f;
    }

    public void UnmuteSounds()
    {
        isSoundOn = true;
        SoundOnButton.SetActive(isSoundOn);
        SoundOffButton.SetActive(!isSoundOn);
        AudioListener.volume = 1f;
    }

    public void WarningMainMenu()
    {
        quitWarningCanvas.SetActive(true);
    }

    private void ConfirmQuit()
    {
        Application.Quit();
        Debug.Log("Application.Quit();");
    }

    private void CancelQuit()
    {
        quitWarningCanvas.SetActive(false);
    }
}
