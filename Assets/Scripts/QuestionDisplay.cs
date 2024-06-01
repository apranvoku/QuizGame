using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;
public class QuestionDisplay : MonoBehaviour
{
    public ChoiceDisplay ChoiceA;
    public ChoiceDisplay ChoiceB;
    public ChoiceDisplay ChoiceC;
    public ChoiceDisplay ChoiceD;

    public TextMeshProUGUI questionText;

    // Start is called before the first frame update
    public void UpdateQuestion(float[]answers, string currentQuestion)
    {
        questionText.text = currentQuestion;
        List<int> indices = new List<int> { 0, 1, 2, 3 }; //Shuffle choices.
        indices = indices.OrderBy(x => Random.value).ToList();
        
        ChoiceA.SetChoice(answers[indices[0]].ToString());
        ChoiceB.SetChoice(answers[indices[1]].ToString());
        ChoiceC.SetChoice(answers[indices[2]].ToString());
        ChoiceD.SetChoice(answers[indices[3]].ToString());
    }
}
