using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform lookAt;
    [SerializeField] private bool _isSmooth = true;
    [SerializeField] private float _smoothSpeed = 0.5f;
    [SerializeField] private float _distance = -5f;
    private Vector3 _offset;

    private void Start()
    {
        _offset = new Vector3(0, 0, _distance);
    }
    private void LateUpdate()
    {

        Vector3 desiredPosition = lookAt.position + _offset;

        if (_isSmooth)
        {
            transform.position = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
        }
        else
        {
            transform.position = desiredPosition;
        }
    }
}
