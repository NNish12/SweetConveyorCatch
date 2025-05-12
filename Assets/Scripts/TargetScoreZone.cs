using UnityEngine;

public class TargetScoreZone : MonoBehaviour
{

 public AudioSource audioSource;
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject != null)
        {
            FallingObjectMarker currentFalling = collision.gameObject.GetComponent<FallingObjectMarker>();
            if (currentFalling != null && !currentFalling.isTargerForDestroy)
            {
                currentFalling.isTargerForDestroy = true;

                if (currentFalling.gameObject.CompareTag("Candy"))
                {
                    CoinsManager.instance.AddLocalCoins(3);
                    CathcingItems.instance.AddCatchItem();
                }
                else if (currentFalling.gameObject.CompareTag("Fruit"))
                {
                    CoinsManager.instance.AddLocalCoins(1);
                    CathcingItems.instance.AddCatchItem();

                }
                else if (currentFalling.gameObject.CompareTag("FastFood"))
                {
                    CoinsManager.instance.LocalCoins = 0;
                    LivesManager.instance.LoseLife();
                }
                audioSource.pitch = Random.Range(0.8f, 1.2f);
                audioSource.Play();
                Destroy(collision.gameObject);
            }
        }
    }
}
