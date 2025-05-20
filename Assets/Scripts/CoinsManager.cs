using Unity.VisualScripting;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    public static CoinsManager instance { get; private set; }


    private int _localCoins = 0;
    private int _globalCoins = 0;
    public int priceLives = 2;
    public int priceCoins = 5;


    public int LocalCoins
    {
        get => _localCoins;
        set
        {
            _localCoins = Mathf.Max(0, value);
            UIUpdate.instance.UpdateLocalCoins(_localCoins);
        }
    }

    public int GlobalCoins
    {
        get => _globalCoins;
        private set
        {
            _globalCoins = Mathf.Max(0, value);
            UIUpdate.instance.UpdateGlobalCoins(_globalCoins);
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
            LivesManager.instance.BuyAdditionalLives();
            priceLives *= 2;
            UIUpdate.instance.UpdateUpgradePriceLives(priceLives);
        }
        else
        {
            Debug.Log("Недостаточно монет для покупки жизни.");
        }
    }
    public void AddLocalCoins(int value) 
    {
        LocalCoins += value;
        UIUpdate.instance.UpdateLocalCoins(LocalCoins);
    }

    public void BuyMoreCatchItems()
    {
        if (GlobalCoins >= priceCoins)
        {
            GlobalCoins -= priceCoins;
            CathcingItems.instance.BuyAdditionalItem();
            priceCoins *= 2;
            UIUpdate.instance.UpdateUpgradePriceCoins(priceCoins);
        }
        else
        {
            Debug.Log("Недостаточно монет для увеличения инвентаря.");
        }
    }
    public void ClearState()
    {
        LocalCoins = 0;
        UIUpdate.instance.UpdateLocalCoins(LocalCoins);
    }
    public void SumOfCoins()
    {
        GlobalCoins += LocalCoins;
        UIUpdate.instance.UpdateGlobalCoins(GlobalCoins);
    }


}