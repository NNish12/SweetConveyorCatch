using UnityEngine;

public class LivesManager : MonoBehaviour
{
    public static LivesManager instance { get; private set; }
    private int lives = 1;

   public int Lives
{
    get => lives;
    set
    {
        lives = value;
        if (lives <= 0)
        {
            EndGame(); // Вызов метода из GameManager
        }
        UIUpdate.instance.UpdateLivesUI(lives);
    }
}
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
       public void LoseLife()
    {
        Lives--;
    }
        private void EndGame()
    {
        UIManager.instance.GameOverManager();
        CoinManager.instance.SumOfCoins();
        // UIUpdate.instance.UpdateGlobalCoinsUI(CoinManager.instance.GlobalCoins);
    }
}