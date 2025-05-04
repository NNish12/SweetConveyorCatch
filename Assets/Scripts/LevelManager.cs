using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int _currentLevel = 1;

    public static LevelManager instance { get; private set; }
    private int _pointTonextLevel;
    // [SerializeField] GameState _gameState;
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
    //     UIUpdate.instance.UpdateLevelUI(_currentLevel);
    // }


    // public void CheckLevelUp()
    // {
    //     if (GameState.instance._caughtCandy >=_pointTonextLevel)
    //     {
    //         LevelUp();
    //     } 

    // }
    // private void LevelUp()
    // {
    //     _currentLevel++;
    //     UIUpdate.instance.UpdateLevelUI(_currentLevel);
    //     // GameState.
    // }

}
