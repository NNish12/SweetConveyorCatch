using UnityEngine;

public class AddScore : MonoBehaviour
{
    [SerializeField] private ScaleDestroyMarker _floorScaleDestroy;


    private void OnTriggerEnter(Collider other)

    {
        if (other.gameObject != null)
        {
            FallingObjectMarker currentFalling = other.gameObject.GetComponent<FallingObjectMarker>();
            if (currentFalling != null && !currentFalling.isTargerForDestroy)
            {
                currentFalling.isTargerForDestroy = true;

                switch (other.gameObject.tag)
                {
                    case "Fruit": GameState.instance.AddScore(10); break;
                    case "Sweets": GameState.instance.AddScore(20); break;
                    case "Other": GameState.instance.AddScore(-10); break;
                }

                Destroy(other.gameObject);
            }
        }
    }
}
