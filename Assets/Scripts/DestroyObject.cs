using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject != null && other.gameObject.GetComponent<FallingObjectMarker>())
        {
            Destroy(other.gameObject);
        }

    }
}
