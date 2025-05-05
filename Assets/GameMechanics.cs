using TMPro;
using UnityEngine;

public class GameMechanics : MonoBehaviour
{
    [SerializeField] private ObjectSpawner _objectSpawner;
    [SerializeField] private GameObject _finalMenu;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private TextMeshProUGUI textFinalMenu;
    private Coroutine _coroutineSpawnObjects;
    public static GameMechanics instance { get; private set; }
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
        textFinalMenu.text = "We don't need fast food!";
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
        StopCoroutine(_coroutineSpawnObjects);
        _objectSpawner.ClearListObjects();
        CoinsManager.instance.SumOfCoins();
        _finalMenu.SetActive(true);
        textFinalMenu.text = "You are win!";
    }
    public void ClearStateAll()
    {
        CoinsManager.instance.ClearState();
        // LivesManager.instance.ClearState();
        CathcingItems.instance.ClearState();
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isGameRunning = true;
    }
}
