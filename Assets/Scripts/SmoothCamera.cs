using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform lookAt;
    [SerializeField] private bool _isSmooth = true;
    [SerializeField] private float _smoothSpeed = 0.5f;
    [SerializeField] private float _distance = -5f;
    private float _initialXOffset;

    private void Start()
    {
        _initialXOffset = transform.position.x - lookAt.position.x + _distance;
    }
    private void LateUpdate()
    {
        Vector3 currentPosition = transform.position;

        // Только если объект двигается — камера следует за ним по X
        float desiredX = lookAt.position.x + _initialXOffset;
        Vector3 desiredPosition = new Vector3(desiredX, currentPosition.y, currentPosition.z);

        if (_isSmooth)
        {
            transform.position = Vector3.Lerp(currentPosition, desiredPosition, _smoothSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = desiredPosition;
        }
    }
}
