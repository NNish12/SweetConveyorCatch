using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float angleX = 0.7f;
    [SerializeField] private float angleY = 0.7f;
    [SerializeField] private float angleZ = 0.7f;

    private void Update()
    {
        transform.Rotate(angleX, angleY, angleZ);
    }
}
