using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;


[Serializable]
public class Question
{
    public float answer;
    public float[] answers;
    public string text;
}
[Serializable]
public class Response
{
    public Question c_question;
    public Question p_question;
    public int round;
    public int score;
    public bool finished;
    public bool started;
}

public class QuizManager : MonoBehaviour
{
    private Response currentResponse;
    public TextMeshProUGUI scoreText;
    public List<string> Questions;
    public Hashtable QuestionAnswers;
    public QuestionDisplay whiteBoard;
    public int prevRound;
    private int score;

    public GameObject finishedCanvas;
    public GameObject WaitingForQuestionCanvas;


    // Start is called before the first frame update
    void Start()
    {
        prevRound = 0;
        finishedCanvas.SetActive(false);
        WaitingForQuestionCanvas.SetActive(true);

        //Update question.
        StartCoroutine(PeriodicGetQuestion());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator PeriodicGetQuestion()
    {
        while(true)
        {
            StartCoroutine(GetNewResponse());
            yield return new WaitForSeconds(2f);
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        ResetTransform resetter = collision.gameObject.GetComponent<ResetTransform>();
        resetter.DoResetTransform();
        Debug.Log("Answer Submitted!");
        float answer = float.Parse(collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().text);
        if(answer - currentResponse.c_question.answer < 0.001f)
        {
            score++;
            scoreText.text = score.ToString();
            WaitingForQuestionCanvas.GetComponentInChildren<TextMeshProUGUI>().text = "Correct! \n Waiting for next question...";
        }
        else
        {
            WaitingForQuestionCanvas.GetComponentInChildren<TextMeshProUGUI>().text = "Wrong! \n Waiting for next question...";
        }
        WaitingForQuestionCanvas.SetActive(true);
        StartCoroutine(SendResponse(answer));
    }


    public IEnumerator GetNewResponse()
    {
        // URL to request JSON data from
        string url = "http://10.2.2.238:5000/gs";

        // Send a GET request to the URL
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            // Send the request and wait for a response
            yield return www.SendWebRequest();

            // Check for errors
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Failed to get JSON data: " + www.error);
            }
            else
            {
                // Get the JSON data from the response
                string jsonData = www.downloadHandler.text;

                // Deserialize JSON data into Person object
                Response response = JsonUtility.FromJson<Response>(jsonData);
                currentResponse = response;
                // Access fields
                Question c_question = response.c_question;
                int round = response.round;
                scoreText.text = score.ToString();
                bool started = response.started;
                bool finished = response.finished;
                if(round != prevRound)
                {
                    WaitingForQuestionCanvas.SetActive(false);
                    prevRound = round;
                    whiteBoard.UpdateQuestion(c_question.answers, c_question.text);
                }
                if(finished)
                {
                    finishedCanvas.SetActive(true);
                    finishedCanvas.GetComponentInChildren<TextMeshProUGUI>().text = "Final Score: " + score.ToString();
                    WaitingForQuestionCanvas.SetActive(false);
                }
            }
        }
    }

    public IEnumerator SendResponse(float answer)
    {
        // URL to send the string to
        string url = "http://10.2.2.238:5000/answer";

        // Create a new form
        WWWForm form = new WWWForm();
        form.AddField("identifier", SystemInfo.deviceUniqueIdentifier);
        form.AddField("answer", answer.ToString());


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
