using UnityEngine;

public class OffsetMaterialConveyor : MonoBehaviour
{
    [SerializeField] private Renderer rend;
    [SerializeField] private float _conveyorRendererSpeed = 0.0475f;
    private Vector2 _offset;
    
    void Start()
    {
        rend = GetComponent<Renderer>();
        _offset = rend.material.mainTextureOffset;
    }

    private void Update()
    {
        float StorageSpeed = MoveStorage.CurrentDirection.x;
        _offset.y += StorageSpeed * Time.deltaTime * _conveyorRendererSpeed;
        rend.material.mainTextureOffset = _offset;
    }
}
