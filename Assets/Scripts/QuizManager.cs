using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public List<string> Questions;
    public Hashtable QuestionAnswers;
    public QuestionDisplay whiteBoard;

    // Start is called before the first frame update
    void Start()
    {
        QuestionAnswers = new Hashtable();

        Questions.Add("Which number is equivalent to 3^4 / 3^2?"); //9
        Questions.Add("There are 48 dogs signed up for a dog show. There are 36 more small dogs than large dogs.How many small dogs have signed up to compete?"); //42
        Questions.Add("Sally is 54 years old and her mother is 80, how many years ago was Sally’s mother three times her age?"); //41
        Questions.Add("What is 1.92÷3"); //0.64
        Questions.Add("A man is climbing up a mountain which is inclined. He has to travel 100 km to reach the top of the mountain. Every day He climbs up 2 km forward in the day time. Exhausted, he then takes rest there at night time. At night, while he is asleep, he slips down 1 km backwards because the mountain is inclined. Then how many days does it take him to reach the mountain top? "); //99
        Questions.Add("Look at this series: 36, 34, 30, 28, 24, … What number should come next?"); //22
        Questions.Add("Eight of my pets aren’t dogs, five aren’t rabbits, and seven aren’t cats. How many pets do I have?"); // 10
        Questions.Add("4 friends entered a maths quiz. One answered one over five of the maths questions, one answered one over ten​, one answered one over four​, and the other answered four over twenty-five.​. What percentage of the questions did they answer altogether?"); //71
        Questions.Add("I have 20 sweets. If I share them equally with my friends, there are 2 left over. If one more person joins us, there are 6 sweets left. How many people total?"); // 6

        QuestionAnswers.Add(Questions[0], new List<float> { 3, 9, 27, 16 });
        QuestionAnswers.Add(Questions[1], new List<float> { 36, 40, 42, 44 });
        QuestionAnswers.Add(Questions[2], new List<float> { 50, 38, 46, 41 });
        QuestionAnswers.Add(Questions[3], new List<float> { 0.60f, 0.64f, 0.65f, 0.66f });
        QuestionAnswers.Add(Questions[4], new List<float> { 100, 50, 49, 99 });
        QuestionAnswers.Add(Questions[5], new List<float> { 20, 22, 24, 23 });
        QuestionAnswers.Add(Questions[6], new List<float> { 21, 12, 10, 8 });
        QuestionAnswers.Add(Questions[7], new List<float> { 71, 64, 89, 80 });
        QuestionAnswers.Add(Questions[8], new List<float> { 4, 3, 6, 8 });

        whiteBoard.UpdateQuestion(QuestionAnswers, Questions[4]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
