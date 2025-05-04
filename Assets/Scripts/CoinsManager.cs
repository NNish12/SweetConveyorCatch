using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CoinsManager : MonoBehaviour
{
    public static CoinsManager instance { get; private set; }

    [SerializeField] private int maxCoinsPerGame = 5;

    private int _localCoins = 0;
    private int _globalCoins = 0;
    public int priceLives = 2;
    public int priceCoins = 5;

    private int _amountForNextLevelCoins = 5;

    public int LocalCoins
    {
        get => _localCoins;
        set
        {
            _localCoins = Mathf.Max(0, value);
            NewUIUpdate.instance.UpdateLocalCoins(_localCoins);
        }
    }

    public int GlobalCoins
    {
        get => _globalCoins;
        private set
        {
            _globalCoins = Mathf.Max(0, value);
            NewUIUpdate.instance.UpdateGlobalCoins(_globalCoins);
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
        if (GlobalCoins >= priceLives)
        {
            GlobalCoins -= priceLives;
            LivesManager.instance.GlobalLives++;
            priceLives *= 2;
            NewUIUpdate.instance.UpdateUpgradePriceLives(priceLives);
        }
        else
        {
            Debug.Log("Недостаточно монет для покупки жизни.");
        }
    }
    public void AddLocalCoins(int value)
    {
        LocalCoins += value;
    }

    public void BuyMoreCoins()
    {
        if (GlobalCoins >= priceCoins)
        {
            GlobalCoins -= priceCoins;
            _amountForNextLevelCoins++;
            priceCoins *= 2;
            NewUIUpdate.instance.UpdateUpgradePriceCoins(priceCoins);
        }
        else
        {
            Debug.Log("Недостаточно монет для увеличения инвентаря.");
        }
    }
    public void ClearState() => LocalCoins = 0;
    public void SumOfCoins()
    {
        GlobalCoins += LocalCoins;
        LocalCoins = 0;
    }


}