using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] public Camera cam;
    [SerializeField] private float _targetSize = 230f;
    [SerializeField] private float _targetSpeed = 300f;
    public float waitingTime = 0.5f;
    private Coroutine currentCoroutine;
    [SerializeField] private ObjectSpawner spawner;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    public void GameModeOn()
    {
        if (currentCoroutine != null) StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(ZoomAfterDelay());
    }

    private IEnumerator ZoomAfterDelay()
    {
        yield return new WaitForSeconds(waitingTime);
        yield return StartCoroutine(CameraZoom(_targetSize));
        GameMechanics.instance.StartGame();
    }

    private IEnumerator CameraZoom(float target)
    {
        while (Mathf.Abs(cam.orthographicSize - target) > 0.01f)
        {
            cam.orthographicSize = Mathf.MoveTowards(cam.orthographicSize, target, _targetSpeed * Time.deltaTime);
            yield return null;
        }
        cam.orthographicSize = target;
    }
}


