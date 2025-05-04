using UnityEngine;
using TMPro;

public class UIUpdate : MonoBehaviour
{
    public static UIUpdate instance { get; private set; }

    [SerializeField] private TextMeshProUGUI _candy;
    [SerializeField] private TextMeshProUGUI _coins;
    [SerializeField] private TextMeshProUGUI _lives;
    [SerializeField] private TextMeshProUGUI _globalCoins;
    [SerializeField] private TextMeshProUGUI _upgradePriceAmountCoins;
    [SerializeField] private TextMeshProUGUI _upgradePriceLives;

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

    }
    public void UpdateAllUI(int globalCoins, int levelCoins, int priceLives, int priceCoin, int lives)
    {
        
    }

    public void UpdateCandyUI(int candy)
    {
        _candy.text = candy.ToString();
    }

    public void UpdateCoinsUI(int coins)
    {
        _coins.text = coins.ToString();
    }

    public void UpdateLivesUI(int lives)
    {
        _lives.text = lives.ToString();
    }

    public void UpdateGlobalCoinsUI(int globalCoins)
    {
        _globalCoins.text = globalCoins.ToString();
    }
    public void UpdateUpgradePriceAmountCoinsUI(int _priceCoinPerLevel)
    {
        _upgradePriceAmountCoins.text = _priceCoinPerLevel.ToString();
    }
    public void UpdateUpgradePriceLivesUI(int _priceLives)
    {
        _upgradePriceLives.text = _priceLives.ToString();
    }
}