using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ResetTransform : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoResetTransform()
    {
        GetComponent<XRGrabInteractable>().enabled = false;
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        GetComponent<XRGrabInteractable>().enabled = true;

    }
}
