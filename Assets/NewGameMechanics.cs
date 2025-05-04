using UnityEngine;

public class NewGameMechanics : MonoBehaviour
{
    [SerializeField] private ObjectSpawner _objectSpawner;
    public static NewGameMechanics instance { get; private set; }
    public bool isGameRunning = false;
    private Coroutine _coroutineSpawnObjects;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        Destroy(this.gameObject);
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
        _coroutineSpawnObjects = StartCoroutine(_objectSpawner.SpawnObjects());
    }
    public void GameOver()
    {
        // Здесь должен быть вызов меню проигрыша, остановка игры и т.д.
        Debug.Log("Game Over");
        Time.timeScale = 0f;
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        isGameRunning = false;
    }
    public void ResetGame()
    {
        Time.timeScale = 0f;
    }
    public void WinGame()
    {
        Time.timeScale = 0f;
    }
        public void ResumeGame()
    {
        Time.timeScale = 1f;
        isGameRunning = true;
    }
    // private void EndGame()
    // {
    //     UIManager.instance.GameOverManager();
    // }
}
