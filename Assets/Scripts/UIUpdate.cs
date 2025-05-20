using TMPro;
using UnityEngine;

public class UIUpdate : MonoBehaviour
{
    public static UIUpdate instance { get; private set; }

    [Header("Coins")]
    [SerializeField] private TextMeshProUGUI _globalCoinsText;
    [SerializeField] private TextMeshProUGUI _localCoinsText;
    [SerializeField] private TextMeshProUGUI _finalLocalCoins;
    [SerializeField] private TextMeshProUGUI _upgradePriceLivesText;
    [SerializeField] private TextMeshProUGUI _upgradePriceCatchText;


    [Header("Lives")]
    [SerializeField] private TextMeshProUGUI _localLivesText;
    [SerializeField] private TextMeshProUGUI _globalLivesText;

    [Header("Catch Items")]
    [SerializeField] private TextMeshProUGUI _globalCatchItemsText;
    [SerializeField] private TextMeshProUGUI _localCatchItemsText;
    


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

    public void UpdateGlobalCoins(int value)
    {
        _globalCoinsText.text = value.ToString();
    }
    public void UpdateAllUI()
    {
        // Обновление монет
        UpdateGlobalCoins(CoinsManager.instance.GlobalCoins);
        UpdateLocalCoins(CoinsManager.instance.LocalCoins);
        UpdateUpgradePriceLives(CoinsManager.instance.priceLives);
        UpdateUpgradePriceCoins(CoinsManager.instance.priceCoins);

        // Обновление жизней
        UpdateGlobalLives(LivesManager.instance.GlobalLives);
        UpdateLocalLives(LivesManager.instance.LocalLives);

        // Обновление пойманных предметов
        UpdateLocalCatchItems(CathcingItems.instance.LocalCatchItems);
        UpdateGlobalCatchItems(CathcingItems.instance.GlobalCatchItems); 
    }

    public void UpdateLocalCoins(int value)
    {
        _localCoinsText.text = value.ToString();
        _finalLocalCoins.text = value.ToString();
    }

    public void UpdateUpgradePriceLives(int value)
    {
        _upgradePriceLivesText.text = value.ToString();
    }

    public void UpdateUpgradePriceCoins(int value)
    {
        _upgradePriceCatchText.text = value.ToString();
    }


    public void UpdateLocalLives(int value)
    {
        _localLivesText.text = value.ToString();
    }

    public void UpdateGlobalLives(int value)
    {
        _globalLivesText.text = value.ToString();
    }

    public void UpdateGlobalCatchItems(int value)
    {
        _globalCatchItemsText.text = value.ToString();
    }
    public void UpdateLocalCatchItems(int value)
    {
        _localCatchItemsText.text = value.ToString();
    }


}