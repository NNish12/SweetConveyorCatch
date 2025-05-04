// using TMPro;
// using UnityEngine;
// using UnityEngine.UI;

// public class GameManager : MonoBehaviour
// {
//     public static GameManager instance { get; private set; }

//     [SerializeField] private GameObject _gameOverMenu;
//     [SerializeField] private int _stepToNextCoinsPerGame;
//     // [SerializeField] private int maxCoinsPerGame = 5;

//     // private int coins = 0;
//     // private int lives = 1;
//     // private int globalCoins = 0;

//     // public int Coins
//     // {
//     //     get => coins;
//     //     private set
//     //     {
//     //         coins = value;
//     //         UIUpdate.instance.UpdateCoinsUI(coins);
//     //     }
//     // }

//     // public int GlobalCoins
//     // {
//     //     get => globalCoins;
//     //     private set
//     //     {
//     //         globalCoins = value;
//     //         UIUpdate.instance.UpdateGlobalCoinsUI(globalCoins);
//     //     }
//     // }

//     // public int Lives
//     // {
//     //     get => lives;
//     //     private set
//     //     {
//     //         lives = value;
//     //         if (lives <= 0)
//     //         {
//     //             EndGame();
//     //         }
//     //         UIUpdate.instance.UpdateLivesUI(lives);
//     //     }
//     // }

//     private void Awake()
//     {
//         if (instance == null)
//             instance = this;
//         else
//             Destroy(gameObject);
//     }

//     private void Start()
//     {
//         CoinManager.instance.Coins= 0;
//         LivesManager.instance.Lives = 1;
//         UIUpdate.instance.UpdateGlobalCoinsUI(CoinManager.instance.GlobalCoins);
//     }

  

 


//     private void EndGame()
//     {
//         Time.timeScale = 0f;
//         GlobalCoins += Coins;
//         _gameOverMenu.SetActive(true);
//     }

//     public void RestartGame()
//     {
//         Time.timeScale = 1f;
//         Coins = 0;
//         Lives = 1;
//         UIUpdate.instance.UpdateCoinsUI(Coins);
//         UIUpdate.instance.UpdateLivesUI(Lives);
//     }
// }