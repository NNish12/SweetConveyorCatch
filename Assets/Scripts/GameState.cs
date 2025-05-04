using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState instance { get; private set; }

    private int _totalScore = 0;
    private int _nextLevelScore = 100;
    public int _caughtCandy = 0;
    private int _level = 1;
    public bool isGameRunning = false;


    public void AddCandyToScore()
    {
        _caughtCandy++;
        // LevelManager.instance.CheckLevelUp();
        UIUpdate.instance.UpdateCandyUI(_caughtCandy);
    }

    public int Level
    {
        get { return _level; }
        set
        {
            _level = value;
            // UIUpdate.instance.UpdateLevelUI(_level);
        }
    }

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

    private void Start()
    {
        // UIUpdate.instance.UpdateLevelUI(Level);
        // UIUpdate.instance.UpdateScoreUI(_totalScore);
    }


    public void AddScore(int score)
    {
        _totalScore = Mathf.Max(0, _totalScore + score);
        // Debug.Log($"totalscore: {_totalScore}, add score: {score}");
        // CheckLevelUp();
        // UIUpdate.instance.UpdateScoreUI(_totalScore);
    }

    public void ResetGame()
    {
        _totalScore = 0;
        isGameRunning = false;

        // UIUpdate.instance.UpdateScoreUI(_totalScore);
        // UIUpdate.instance.UpdateLevelUI(Level);
    }
}