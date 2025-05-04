using UnityEngine;

public class NewGameMechanics : MonoBehaviour
{
    [SerializeField] private ObjectSpawner _objectSpawner;
    [SerializeField] private GameObject _finalMenu;
    [SerializeField] private GameObject _pauseButton;
    private Coroutine _coroutineSpawnObjects;
    public static NewGameMechanics instance { get; private set; }
    public bool isGameRunning = false;
    public bool isCoinAwardAllowed = false;

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

    // private void Start()
    // {
    //     // int localCoins = CoinsManager.instance.LocalCoins;
    // } 
        public void StartGame()
    {
        Time.timeScale = 1f;
        _coroutineSpawnObjects = StartCoroutine(_objectSpawner.SpawnObjects());
        isGameRunning = true;
    }
    public void GameOver()
    {
        // Здесь должен быть вызов меню проигрыша, остановка игры и т.д.
        Debug.Log("Game Over");
        ResetGame();
        isCoinAwardAllowed = true;
        isGameRunning = false;
        CoinsManager.instance.SumOfCoins();
        _finalMenu.SetActive(true);
        _pauseButton.SetActive(false);
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
        NewUIUpdate.instance.UpdateLocalCoins(CoinsManager.instance.LocalCoins);
        StopCoroutine(_coroutineSpawnObjects);
        _objectSpawner.ClearListObjects();
        Time.timeScale = 1f;


    }
    public void WinGame()
    {
        isCoinAwardAllowed = true;
        isGameRunning = false;
        // Time.timeScale = 0f;
        StopCoroutine(_coroutineSpawnObjects);
        _objectSpawner.ClearListObjects();
        _finalMenu.SetActive(true);
        
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isGameRunning = true;
    }
}
