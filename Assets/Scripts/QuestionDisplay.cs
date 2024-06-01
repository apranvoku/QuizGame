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
    public void UpdateQuestion(Hashtable QuestionAnswers, string currentQuestion)
    {
        questionText.text = currentQuestion;
        List<int> indices = new List<int> { 1, 2, 3, 4 }; //Shuffle choices.
        indices = indices.OrderBy(x => Random.value).ToList();
        
        List<float> choices = (List<float>)QuestionAnswers[currentQuestion];

        ChoiceA.SetChoice(choices[indices[0]].ToString());
        ChoiceB.SetChoice(choices[indices[1]].ToString());
        ChoiceC.SetChoice(choices[indices[2]].ToString());
        ChoiceD.SetChoice(choices[indices[3]].ToString());
    }
}
