using TMPro;
using UnityEngine;

public class GameMechanics : MonoBehaviour
{
    [SerializeField] private ObjectSpawner _objectSpawner;
    [SerializeField] private GameObject _finalMenu;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private TextMeshProUGUI _textFinalMenu;
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _coroutineSpawnObjects;

    public static GameMechanics instance { get; private set; }

    public bool isGameRunning { get; private set; } = false;
    public bool isCoinAwardAllowed { get; private set; } = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetIsGameRunning(bool value)
    {
        isGameRunning = value;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        ClearStateAll();
        _coroutineSpawnObjects = StartCoroutine(_objectSpawner.SpawnObjects());
    }

    public void GameOver()
    {
        if (!isCoinAwardAllowed)
            CoinsManager.instance.LocalCoins = 0;

        isCoinAwardAllowed = true;
        EndGameCommon();
        ShowFinalMenu("We don't need fast food!");
    }

    public void WinGame()
    {
        isCoinAwardAllowed = true;
        EndGameCommon();
        ShowFinalMenu("You are win!");
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isGameRunning = false;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isGameRunning = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ResetGame()
    {
        if (!isCoinAwardAllowed)
            CoinsManager.instance.LocalCoins = 0;

        StopObjectSpawning();
        _objectSpawner.ClearListObjects();
        Time.timeScale = 1f;
    }

    public void ClearStateAll()
    {
        CoinsManager.instance.ClearState();
        LivesManager.instance.ClearState();
        CathcingItems.instance.ClearState();
    }

    private void StopObjectSpawning()
    {
        if (_coroutineSpawnObjects != null)
        {
            StopCoroutine(_coroutineSpawnObjects);
            _coroutineSpawnObjects = null;
        }
    }

    private void EndGameCommon()
    {
        StopObjectSpawning();
        _objectSpawner.ClearListObjects();
        _audioSource.Play();
        CoinsManager.instance.SumOfCoins();
        Time.timeScale = 0f;
        isGameRunning = false;
    }

    private void ShowFinalMenu(string message)
    {
        _finalMenu.SetActive(true);
        _pauseButton.SetActive(false);
        _textFinalMenu.text = message;
    }
}