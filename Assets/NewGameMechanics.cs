using Unity.VisualScripting;
using UnityEngine;

public class NewGameMechanics : MonoBehaviour
{
    [SerializeField] private ObjectSpawner _objectSpawner;
    public static NewGameMechanics instance { get; private set; }
    public bool isGameRunning = false;
    private Coroutine _coroutineSpawnObjects;
    public bool isCoinAwardAllowed = false;
    private void Awake()
    {
        if (instance)
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
        ResetGame();
        isCoinAwardAllowed = true;
        CoinsManager.instance.SumOfCoins();
        //меню нынешних очков надо открыть + создать его

    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        isGameRunning = false;
    }
    public void ResetGame()
    {
        if (!isCoinAwardAllowed) CoinsManager.instance.LocalCoins = 0;
        StopCoroutine(_coroutineSpawnObjects);
        _objectSpawner.ClearListObjects();
        Time.timeScale = 1f;
        
    }
    public void WinGame()
    {
        isCoinAwardAllowed = true;
        // Time.timeScale = 0f;
        StopCoroutine(_coroutineSpawnObjects);
        _objectSpawner.ClearListObjects();
        
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isGameRunning = true;
    }
}
