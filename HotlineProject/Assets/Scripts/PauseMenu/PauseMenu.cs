using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseCanvas;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _returnButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _pauseButton;

    [SerializeField] private GameObject _warningCanvas;
    [SerializeField] private Button _confirmButton;
    [SerializeField] private Button _cancelButton;

    public SoundManager soundManager;

    private bool _isPaused = false;

    private void Start()
    {
        _pauseCanvas.SetActive(false);
        _warningCanvas.SetActive(false);

        _resumeButton.onClick.AddListener(ResumeGame);
        _returnButton.onClick.AddListener(ShowReturnWarning);
        _quitButton.onClick.AddListener(ShowQuitWarning);

        _confirmButton.onClick.AddListener(ConfirmAction);
        _cancelButton.onClick.AddListener(CancelAction);
    }

    public void PauseGame()
    {
        _isPaused = true;
        _pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        _pauseButton.interactable = false;
    }

    public void ResumeGame()
    {
        _isPaused = false;
        _pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        _pauseButton.interactable = true;
        soundManager.ReproducirSonido("poker_sound");
    }

    private void ShowReturnWarning()
    {
        _warningCanvas.SetActive(true);
    }

    private void ShowQuitWarning()
    {
        _warningCanvas.SetActive(true);
    }

    private void ConfirmAction()
    {
        if (_returnButton.interactable)
        {
            Time.timeScale = 1f;
            soundManager.ReproducirSonido("poker_sound");
            LoadMainMenu();
        }
        else if (_quitButton.interactable)
        {
            Application.Quit();
        }
    }

    private void CancelAction()
    {
        _warningCanvas.SetActive(false);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}



