using System.Collections;
using UnityEngine;

public class DestroyOnImpactZone : MonoBehaviour
{
    [SerializeField] private float shrinkDuration = 1f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != null)
        {
            FallingObjectMarker fallingObject = collision.gameObject.GetComponent<FallingObjectMarker>();
            if (fallingObject != null && !fallingObject.isTargerForDestroy)
            {
                fallingObject.isTargerForDestroy = true;
                StartCoroutine(ShrinkAndDestroy(collision.gameObject, shrinkDuration));
            }
        }
    }
    public IEnumerator ShrinkAndDestroy(GameObject obj, float duration = 1f)
    {
        if (obj == null) yield break; 

        Vector3 startScale = obj.transform.localScale;
        float timer = 0f;

        while (timer < duration)
        {
            if (obj == null) yield break; 

            timer += Time.deltaTime;
            float scaleAmount = Mathf.Lerp(1f, 0f, timer / duration);
            obj.transform.localScale = startScale * scaleAmount;
            yield return null;
        }

        if (obj != null)
        {
            Destroy(obj);
        }
    }

}
