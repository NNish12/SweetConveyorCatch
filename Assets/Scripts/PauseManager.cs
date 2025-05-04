using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuUI;
    [SerializeField] private GameObject _backgroundImage;
    [SerializeField] private GameObject _pauseButton;
    public void PauseButton()
    {
        Time.timeScale = 0f;
        UIManager.isGameRunning = false;
        _pauseMenuUI.SetActive(true);
        _backgroundImage.SetActive(true);
        _pauseButton.SetActive(false);
    }
    public void ResumeButton()
    {
        Time.timeScale = 1f;
        UIManager.isGameRunning = true;
        _pauseMenuUI.SetActive(false);
        _backgroundImage.SetActive(false);
        _pauseButton.SetActive(true);
    }
}
