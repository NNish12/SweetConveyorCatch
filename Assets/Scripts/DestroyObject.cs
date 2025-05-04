using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != null && other.gameObject.GetComponent<FallingObjectMarker>())
        {
            Destroy(other.gameObject);
        }

    }
}
