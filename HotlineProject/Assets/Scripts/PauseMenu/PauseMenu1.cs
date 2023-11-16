using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu1 : MonoBehaviour
{
    [SerializeField] private GameObject _pauseCanvas;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _returnButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _pauseButton;


    public void PauseGame()
    {
        //_isPaused = true;
        _pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
       // _pauseButton.interactable = false;
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
        Time.timeScale = 1f;
        _pauseCanvas.SetActive(false);

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


