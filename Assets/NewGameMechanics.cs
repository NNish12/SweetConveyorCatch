using UnityEngine;

public class NewGameMechanics : MonoBehaviour
{
    [SerializeField] private ObjectSpawner _objectSpawner;
    private Coroutine _coroutineSpawnObjects;
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

    }
    public void ResetGame()
    {
        Time.timeScale = 0f;
    }
    public void WinGame()
    {
        Time.timeScale = 0f;
    }
    // private void EndGame()
    // {
    //     UIManager.instance.GameOverManager();
    // }
}
