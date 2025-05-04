using UnityEngine;
using TMPro;

public class UIUpdate : MonoBehaviour
{
    public static UIUpdate instance { get; private set; }

    [SerializeField] private TextMeshProUGUI _candy;
    [SerializeField] private TextMeshProUGUI _coins;
    [SerializeField] private TextMeshProUGUI _lives;
    [SerializeField] private TextMeshProUGUI _globalCoins;

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
}