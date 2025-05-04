using UnityEngine;
using UnityEditor;

public class NormalizeSize : MonoBehaviour
{
    [MenuItem("Tools/Normalize Selected Objects")]
    private static void NormalizeSelected()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            var renderers = obj.GetComponentsInChildren<Renderer>();
            if (renderers.Length == 0) continue;

            Bounds bounds = renderers[0].bounds;
            foreach (Renderer r in renderers)
                bounds.Encapsulate(r.bounds);

            float maxSize = Mathf.Max(bounds.size.x, bounds.size.y, bounds.size.z);
            if (maxSize == 0) continue;

            float scaleFactor = 5f / maxSize;
            obj.transform.localScale *= scaleFactor;
        }
    }
}