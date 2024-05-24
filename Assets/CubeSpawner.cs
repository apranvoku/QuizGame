using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject hitTarget;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCubes());
    }
    public IEnumerator SpawnCubes()
    {
        while(true)
        {
            Instantiate(hitTarget, transform.position - Vector3.forward, Quaternion.identity, transform);
            yield return new WaitForSeconds(1f);
        }
    }
}
