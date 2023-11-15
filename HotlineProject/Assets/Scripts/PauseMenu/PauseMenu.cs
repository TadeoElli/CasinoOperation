using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseCanvas;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _returnButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _pauseButton;

    //private bool _isPaused = false;

    private void Start()
    {
        _pauseCanvas.SetActive(false);

        _resumeButton.onClick.AddListener(ResumeGame);

        _restartButton.onClick.AddListener(RestartGame);

        _returnButton.onClick.AddListener(ReturnToMenu);

        Time.timeScale = 1f;
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
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}


