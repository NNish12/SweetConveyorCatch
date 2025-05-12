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
    public AudioSource audioSource;
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
        ClearStateAll();
        _coroutineSpawnObjects = StartCoroutine(_objectSpawner.SpawnObjects());
        // isGameRunning = true;
    }
    public void GameOver()
    {
        ResetGame();
        Time.timeScale = 0f;
        isCoinAwardAllowed = true;
        audioSource.Play();
        isGameRunning = false;
        CoinsManager.instance.SumOfCoins();
        _finalMenu.SetActive(true);
        textFinalMenu.text = "We don't need fast food!";
        _pauseButton.SetActive(false);

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
        isGameRunning = false;
        audioSource.Play();
        StopCoroutine(_coroutineSpawnObjects);
        _objectSpawner.ClearListObjects();
        CoinsManager.instance.SumOfCoins();
        _finalMenu.SetActive(true);
        _pauseButton.SetActive(false);
        Time.timeScale = 0f;
        textFinalMenu.text = "You are win!";

    }
    public void ClearStateAll()
    {
        CoinsManager.instance.ClearState();
        LivesManager.instance.ClearState();
        CathcingItems.instance.ClearState();
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isGameRunning = true;
    }
}
