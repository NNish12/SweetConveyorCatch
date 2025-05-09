using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Camera cam;
    
    [Header("Zoom Settings")]
    [SerializeField] private float _targetSize = 230f;
    [SerializeField] private float _zoomLerpSpeed = 5f;

    [Header("Position Settings")]
    [SerializeField] private float _moveLerpSpeed = 2f;
    [SerializeField] private float _waitingTime = 1f;
    [SerializeField] private float _positionThreshold = 0.01f;

    private Coroutine currentCoroutine;

    private void Start()
    {
        if (cam == null)
            cam = GetComponent<Camera>();
    }

    public void GameModeOn()
    {
        if (currentCoroutine != null) StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(StartTransition());
    }

    private IEnumerator StartTransition()
    {
        yield return new WaitForSeconds(_waitingTime);

        // Стартуем оба процесса параллельно
        Coroutine zoomCoroutine = StartCoroutine(ExponentialZoom(_targetSize));
        Coroutine moveCoroutine = StartCoroutine(ExponentialMove(target.position));

        yield return zoomCoroutine;
        yield return moveCoroutine;
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

    private IEnumerator ExponentialMove(Vector3 targetPosition)
    {
        while ((transform.position - targetPosition).sqrMagnitude > _positionThreshold * _positionThreshold)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, _moveLerpSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPosition;
    }
}