using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class DeviceNameGetter : MonoBehaviour
{
    private List<InputDevice> inputDevices;
    public string deviceName;
    void Start()
    {
        StartCoroutine(WaitForDetect());

    }
    public IEnumerator WaitForDetect()
    {
        yield return new WaitUntil(() => SystemInfo.deviceUniqueIdentifier != null);
        PassToServer(SystemInfo.deviceUniqueIdentifier);
    }
    public void PassToServer(string deviceUniqueIdentifier)
    {
        Debug.Log(deviceUniqueIdentifier);
        //PasstoServer;
    }

}
