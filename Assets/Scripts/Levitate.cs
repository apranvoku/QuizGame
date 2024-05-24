using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitate : MonoBehaviour
{
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

// Update is called once per frame
void Update()
    {
        this.transform.position = startPosition + new Vector3(0f, Mathf.Sin(Time.time)*0.3f, 0f);
    }
}
