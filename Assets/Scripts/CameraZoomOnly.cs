using System.Collections;
using UnityEngine;

public class CameraZoomOnly : MonoBehaviour
{
    public Camera cam;

    [SerializeField] private float _targetSize = 230f;
    [SerializeField] private float _zoomLerpSpeed = 5f;

    private Coroutine _zoomCoroutine;

    private void Start()
    {
        if (cam == null)
            cam = GetComponent<Camera>();
    }

    public void StartZoom()
    {
        if (_zoomCoroutine != null)
            StopCoroutine(_zoomCoroutine);

        _zoomCoroutine = StartCoroutine(ExponentialZoom(_targetSize));
    }

    private IEnumerator ExponentialZoom(float target)
    {
        while (Mathf.Abs(cam.orthographicSize - target) > 0.01f)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, target, _zoomLerpSpeed * Time.deltaTime);
            yield return null;
        }

        cam.orthographicSize = target;
    }
}