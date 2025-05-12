using UnityEngine;

public class MoveStorage : MonoBehaviour
{
    private readonly string Horizontal = "Horizontal";

    [SerializeField] private float _moveSpeed = 20f;
    [SerializeField] private float minX = -5f;
    [SerializeField] private float maxX = 5f;
    public static Vector3 CurrentDirection;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float moveX = Input.GetAxis(Horizontal) * _moveSpeed * Time.deltaTime;
        float targetX = Mathf.Clamp(transform.position.x + moveX, startPosition.x + minX, startPosition.x + maxX);

        CurrentDirection = new Vector3 (Input.GetAxis(Horizontal) * _moveSpeed, 0f, 0f);


        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
    }

}
