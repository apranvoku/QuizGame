using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChoiceDisplay : MonoBehaviour
{
    public void SetChoice(string choice)
    {
        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();
        foreach(TextMeshProUGUI text in texts)
        {
            text.text = choice;
        }
    }

}
