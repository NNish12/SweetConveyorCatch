using UnityEngine;
using System.Collections;

public class DisableRigidbodyCandies : MonoBehaviour
{
    public GameObject[] candies;

    void Start()
    {
        StartCoroutine(DisableRigidBody());
    }

    IEnumerator DisableRigidBody()
    {
        yield return new WaitForSeconds(6); 
        for (int i = 0; i < candies.Length; i++)
        {
            candies[i].GetComponent<Rigidbody>().isKinematic = true; 
        }
    }
}
