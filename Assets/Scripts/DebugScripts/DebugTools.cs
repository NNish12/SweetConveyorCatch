
using UnityEngine;

public class DebugTools : MonoBehaviour
{
    [SerializeField] public GameObject[] spawnObjects;
    [SerializeField] public ObjectSpawner _objectSpawner;
    [SerializeField] private float spacing = 5f;

    public void SpawnAllObjects()
    {
        spawnObjects = _objectSpawner.spawnObject;
        Vector3 spawnPos = transform.position;

        for (int i = 0; i < spawnObjects.Length; i++)
        {
            var randomRotation = RandomRotation();

            GameObject temp = Instantiate(spawnObjects[i], spawnPos, Quaternion.Euler(randomRotation));
            temp.GetComponent<Rigidbody>().isKinematic = true;
            temp.GetComponent<Rotate>().enabled = false;
            spawnPos.x += spacing; // сдвиг по оси X
        }
    }
    public void SpawnOneObject()
    {
        spawnObjects = _objectSpawner.spawnObject;
        Vector3 spawnPos = transform.position;

        var randomRotation = RandomRotation();
            GameObject temp = Instantiate(spawnObjects[Random.Range(0, spawnObjects.Length)], spawnPos, Quaternion.Euler(randomRotation));
            temp.GetComponent<Rigidbody>().isKinematic = true;
            temp.GetComponent<Rotate>().enabled = false;
    }

    public Vector3 RandomRotation()
    {
        Vector3 randomRotation = new Vector3(
            Random.Range(-50f, 0f),
            Random.Range(-50f, 50f),
            Random.Range(-30f, 30f));
        return randomRotation;
    }
}

