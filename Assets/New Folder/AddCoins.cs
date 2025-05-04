using UnityEngine;

public class AddCoins : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Candy")) 
        {
            CoinManager.instance.AddCoins(3);
        } else if (other.gameObject.CompareTag("Fruit"))
        {
            CoinManager.instance.AddCoins(1);
        } else if (other.gameObject.CompareTag("FastFood"))
        {
            LivesManager.instance.LoseLife();
        }
    }
}
