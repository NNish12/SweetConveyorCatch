using UnityEngine;
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _menuPauseUI;
    [SerializeField] private GameObject _debugUI;
    [SerializeField] private GameObject _mainMenuUI;
    [SerializeField] private GameObject _backgroundImage;
    [SerializeField] private GameObject _settingsUI;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _uiBar;
    [SerializeField] private GameObject _ImageLogo;
    [SerializeField] private PauseManager _pauseManager;
    [SerializeField] private ObjectSpawner _objectSpawner;
    [SerializeField] private GameObject _globalCoinsUI;
    public static UIManager instance { get; private set; }
    public static bool isGameRunning = false;
    private Coroutine _coroutineSpawnObjects;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isGameRunning)
        {
            _pauseManager.PauseButton();
        }
    }
    public void OnExitGame()
    {
        Application.Quit();
    }
    public void ShowLogo(bool show)
    {
        _ImageLogo.SetActive(show);
    }
    public void OnStartGame()
    {
        _uiBar.SetActive(true);
        _coroutineSpawnObjects = StartCoroutine(_objectSpawner.SpawnObjects());
        isGameRunning = true;
        Time.timeScale = 1f;
    }
    public void BackToMainMenu()
    {
        GameState.instance.ResetGame();
        StopCoroutine(_coroutineSpawnObjects);
        _objectSpawner.ClearListObjects();
    }
    public void GameOverManager()
    {
        Time.timeScale = 0f;
        _mainMenuUI.SetActive(true);
        _globalCoinsUI.SetActive(true);
    }
}
