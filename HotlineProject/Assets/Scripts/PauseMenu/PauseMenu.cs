using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseCanvas;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _returnButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _pauseButton;

    //private bool _isPaused = false;

    public SoundManager soundManager;

    private void Start()
    {

        _pauseCanvas.SetActive(false);

        _resumeButton.onClick.AddListener(ResumeGame);

        _restartButton.onClick.AddListener(RestartGame);

        _returnButton.onClick.AddListener(ReturnToMenu);

       // Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        //_isPaused = true;
        _pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        _pauseButton.interactable = false;
        
    }

    public void ResumeGame()
    {
        //_isPaused = false;
        _pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        _pauseButton.interactable = true;
        soundManager.ReproducirSonido("poker_sound");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        soundManager.ReproducirSonido("poker_sound");
        _pauseButton.interactable = true;
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Invoke("LoadRestartScene", 0.2f);
    }
    private void LoadRestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        soundManager.ReproducirSonido("poker_sound");

        Invoke("LoadMainMenu", 0.2f);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}


