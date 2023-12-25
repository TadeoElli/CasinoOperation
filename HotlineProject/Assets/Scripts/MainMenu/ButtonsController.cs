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
    public GameObject objetoControls;
    public Button confirmQuitButton;
    public Button cancelQuitButton;

    private bool objetoLevelsActive = false;
    private bool objetoCustomizeActive = false;
    private bool objetoStatsActive = false;
    private bool objetoControlsActive = false;
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
        objetoControlsActive = false;

        objetoLevels.SetActive(objetoLevelsActive);
        objetoCustomize.SetActive(objetoCustomizeActive);
        objetoStats.SetActive(objetoStatsActive);
        objetoControls.SetActive(objetoControlsActive);
    }

    public void DeleteStats()
    {
        objetoLevelsActive = false;
        objetoCustomizeActive = false;
        objetoStatsActive = true;
        objetoControlsActive = false;

        objetoLevels.SetActive(objetoLevelsActive);
        objetoCustomize.SetActive(objetoCustomizeActive);
        objetoStats.SetActive(objetoStatsActive);
        objetoControls.SetActive(objetoControlsActive);
    }


    public void OkButton()
    {
        objetoLevelsActive = false;
        objetoStatsActive = false;
        objetoCustomizeActive = false;
        objetoControlsActive = false;

        objetoLevels.SetActive(objetoLevelsActive);
        objetoCustomize.SetActive(objetoCustomizeActive);
        objetoStats.SetActive(objetoStatsActive);
        objetoControls.SetActive(objetoControlsActive);
    }

    public void Customize()
    {
        objetoCustomizeActive = true;
        objetoLevelsActive = false;
        objetoStatsActive = false;
        objetoControlsActive = false;

        objetoLevels.SetActive(objetoLevelsActive);
        objetoCustomize.SetActive(objetoCustomizeActive);
        objetoStats.SetActive(objetoStatsActive);
        objetoControls.SetActive(objetoControlsActive);
    }
    public void Controls()
    {
        objetoCustomizeActive = false;
        objetoLevelsActive = false;
        objetoStatsActive = false;
        objetoControlsActive = true;
        
        objetoLevels.SetActive(objetoLevelsActive);
        objetoCustomize.SetActive(objetoCustomizeActive);
        objetoStats.SetActive(objetoStatsActive);
        objetoControls.SetActive(objetoControlsActive);
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
