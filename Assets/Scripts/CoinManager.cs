using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance { get; private set; }
    [SerializeField] private int maxCoinsPerGame = 5;

    private int _levelCoins = 0;
    private int _globalCoins = 0;
    private int _priceLives = 2;
    private int _amountForNextLevelCoins = 5;
    private int _priceCoinPerLevel = 5;
    public int LevelCoins
    {
        get => _levelCoins;
        set
        {
            _levelCoins = Mathf.Max(0, value); // Никогда не уходит в минус
            UIUpdate.instance.UpdateCoinsUI(_levelCoins);
        }
    }
    public int GlobalCoins
    {
        get => _globalCoins;
        private set
        {
            _globalCoins = value;
            UIUpdate.instance.UpdateGlobalCoinsUI(_globalCoins);
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
        if (GlobalCoins >= _priceLives)
        {
            GlobalCoins -= _priceLives;
            LivesManager.instance.Lives++;
            _priceLives *= 2;
            UIUpdate.instance.UpdateUpgradePriceLivesUI(_priceLives);
        }
        else
        {
            Debug.Log("Недостаточно монет для покупки жизни.");
        }
    }
    public void BuyMoreCoins()
    {
        if (GlobalCoins >= _priceCoinPerLevel)
        {
            GlobalCoins -= _priceCoinPerLevel;
            _amountForNextLevelCoins++;
            _priceCoinPerLevel *= 2;
            UIUpdate.instance.UpdateUpgradePriceAmountCoinsUI(_priceCoinPerLevel);
        }
        else
        {
            Debug.Log("Недостаточно монет для увеличения инвенторя.");
        }
    }
    public void SumOfCoins()
    {
        GlobalCoins += LevelCoins;
        UIUpdate.instance.UpdateGlobalCoinsUI(GlobalCoins);
        LevelCoins = 0;
    }
    public void EndGame()
    {

    }
    public void CheckCoins() //метод вызываеся кгда монета попадает в триггер в корзине
    {
        if (LevelCoins >=_amountForNextLevelCoins)
        {
            EndGame();
            SumOfCoins();
            //загрузка базовой сцены с UI menu
        }
    }
}
