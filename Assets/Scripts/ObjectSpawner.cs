using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] spawnObject;
    [SerializeField] private float spawnTime = 2f;
    [SerializeField] private float _spaceMin = -30f;
    [SerializeField] private float _spaceMax = 30f;
    [SerializeField] private float _forceAmout = 10f;
    private List<GameObject> _spawnedObjects = new List<GameObject>();


    public IEnumerator SpawnObjects()
    {
        if (!NewGameMechanics.instance.isGameRunning)
        {
            while (true) //здесь условие на конечный счет
            {
                CreateOneObject();
                yield return new WaitForSeconds(spawnTime);
            }
        }
    }
    public void CreateOneObject()
    {
        float pointX = Random.Range(_spaceMin, _spaceMax);
        Vector3 currentlyPosition = new Vector3(transform.position.x + pointX, transform.position.y, transform.position.z);
        Vector3 randomRotation = new Vector3(
            Random.Range(-50f, 0f),
            Random.Range(-50f, 50f),
            Random.Range(-30f, 30f));

        GameObject obj = Instantiate(spawnObject[Random.Range(0, spawnObject.Length)], currentlyPosition, Quaternion.Euler(randomRotation));
        _spawnedObjects.Add(obj);
        Rigidbody rg = obj.GetComponent<Rigidbody>();
        rg.AddForce(Vector3.down * _forceAmout, ForceMode.Impulse);
    }
    public void ClearListObjects()
    {
        foreach(var obj in _spawnedObjects) Destroy(obj);
        _spawnedObjects.Clear();
    }

}