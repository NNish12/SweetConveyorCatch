// using System.Collections;
// using UnityEngine;

// public class ConveyorCollision : MonoBehaviour
// {
//     [SerializeField] private float shrinkDuration = 1f;
//     private void OnCollisionEnter(Collision collision)
//     {
//         if (collision.gameObject.GetComponent<FallingObjectMarker>())
//             StartCoroutine(ShrinkAndDestroy(collision.gameObject, shrinkDuration));
//     }


//     public IEnumerator ShrinkAndDestroy(GameObject obj, float duration = 1f)
//     {
//         Vector3 startScale = obj.transform.localScale;
//         float timer = 0f;

//         while (timer < duration)
//         {
//             timer += Time.deltaTime;
//             float scaleAmount = Mathf.Lerp(1f, 0f, timer / duration);
//             obj.transform.localScale = startScale * scaleAmount;
//             yield return null;
//         }

//         Destroy(obj);
//     }
// }
