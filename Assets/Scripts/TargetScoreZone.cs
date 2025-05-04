using UnityEngine;

public class TargetScoreZone : MonoBehaviour
{
    // [SerializeField] private DestroyOnImpactZone _floorScaleDestroy;


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
                    CathcingItems.instance.CatchItemCount();
                    CoinsManager.instance.AddLocalCoins(3);
                }
                else if (currentFalling.gameObject.CompareTag("Fruit"))
                {
                    CathcingItems.instance.CatchItemCount();
                    CoinsManager.instance.AddLocalCoins(1);
                }
                else if (currentFalling.gameObject.CompareTag("FastFood"))
                {
                    LivesManager.instance.LoseLife();
                }
                Destroy(collision.gameObject);
            }
        }
    }
}
