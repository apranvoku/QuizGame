using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.XR;

public class DeviceNameGetter : MonoBehaviour
{
    private List<InputDevice> inputDevices;
    public string deviceUniqueIdentifier;
    void Start()
    {
        StartCoroutine(PassToServer());

    }

    public IEnumerator PassToServer()
    {
        // URL to send the string to
        string url = "https://game.incntr.vladb.xyz/join";

        // String to send
        string data = "Q4";

        // Create a new form
        WWWForm form = new WWWForm();
        form.AddField("identifier", data);

        // Send a POST request to the URL with the string data
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            // Send the request and wait for a response
            yield return www.SendWebRequest();

            // Check for errors
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Failed to send string data: " + www.error);
            }
            else
            {
                Debug.Log("String data sent successfully!");
            }
        }
    }
}
