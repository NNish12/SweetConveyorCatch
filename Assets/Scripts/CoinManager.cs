using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance { get; private set; }
    [SerializeField] private int maxCoinsPerGame = 5;

    private int coins = 0;
    private int globalCoins = 0;
    private int priceForLive = 2;
    public int Coins
    {
        get => coins;
        set
        {
            coins = Mathf.Max(0, value); // Никогда не уходит в минус
            UIUpdate.instance.UpdateCoinsUI(coins);
        }
    }

    public int GlobalCoins
    {
        get => globalCoins;
        private set
        {
            globalCoins = value;
            UIUpdate.instance.UpdateGlobalCoinsUI(globalCoins);
        }
    }
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    public void BuyLife()
    {
        if (Coins >= priceForLive)
        {
            Coins -= priceForLive;
            LivesManager.instance.Lives++;
            priceForLive *= 2;
        }
        else
        {
            Debug.Log("Недостаточно монет для покупки жизни.");
        }
    }
    public void AddCoins(int amount)
    {
        Coins += amount;
        if (Coins >= maxCoinsPerGame)
        {
            // EndGame();
        }
    }
    public void SumOfCoins()
    {
        GlobalCoins += Coins;
        UIUpdate.instance.UpdateGlobalCoinsUI(GlobalCoins);
        Coins = 0;
    }
}
