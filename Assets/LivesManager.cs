using Unity.VisualScripting;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    public static LivesManager instance { get; private set; }

    private int _localLives = 0;
    private int _globalLives = 1;

    public int LocalLives
    {
        get => _localLives;
        private set
        {
            _localLives = value;
            NewUIUpdate.instance.UpdateLocalLives(_localLives);

            if (_localLives <= 0)
            {
                // EndGame();
            }
        }
    }

    public int GlobalLives
    {
        get => _globalLives;
        set
        {
            _globalLives = Mathf.Max(0, value);
            NewUIUpdate.instance.UpdateGlobalLives(_globalLives);

            if (_globalLives <= 0)
            {
                // EndGame();
            }
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        LocalLives = GlobalLives;
    }

    public void LoseLife()
    {
        LocalLives--;
        NewUIUpdate.instance.UpdateLocalLives(LocalLives);
    }
    public void ClearState() => LocalLives = GlobalLives;
    // private void EndGame()
    // {
    //     // UIManager.instance.GameOverManager();
    //     CoinsManager.instance.SumOfCoins();
    // }
    private void Start()
    {
        NewUIUpdate.instance.UpdateAllUI();
    }

}