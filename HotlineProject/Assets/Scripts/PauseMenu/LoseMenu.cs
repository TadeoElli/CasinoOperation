using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _loseCanvas;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _returnButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _loseButton;

    //private bool _isPaused = false;

    private void Start()
    {
        _loseCanvas.SetActive(false);

        _resumeButton.onClick.AddListener(ResumeGame);

        _restartButton.onClick.AddListener(RestartGame);

        _returnButton.onClick.AddListener(ReturnToMenu);

        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        //_isPaused = true;
        _loseCanvas.SetActive(true);
        Time.timeScale = 0f;
        _loseButton.interactable = false;
    }

    public void ResumeGame()
    {
        //_isPaused = false;
        _loseCanvas.SetActive(false);
        Time.timeScale = 1f;
        _loseButton.interactable = true;
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


