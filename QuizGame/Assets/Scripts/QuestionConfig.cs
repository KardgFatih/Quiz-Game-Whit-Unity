using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data;
using System.Linq;

public class QuestionConfig : MonoBehaviour
{   
    [SerializeField] private QuestionsDatas questionsDatas;
    [SerializeField] private Questions currentQuestion;
    [SerializeField] private TextMeshProUGUI questionText;
    //ID = 0 => The text of the answer_1 button, ID = 1 => The text of the answer_2 button ...
    [SerializeField] private TextMeshProUGUI[] answersText;

    // questions[selectedID].QuestionsDatas = questions[selectedID].QuestionsDatas.OrderBy(i => Random.value).ToList();
    public int currenntQuestionID;

    void Start()
    {
        MixOrder();
        ConfigQuestion();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            currenntQuestionID += 1;
            NextQuestion();
        }
    }

    // 
    private void NextQuestion()
    {
        currenntQuestionID += 1;
        ConfigQuestion(); ;
    }

    private void ConfigQuestion()
    {
        currentQuestion = questionsDatas.questionintheEpisode[currenntQuestionID];

        // if the questions are not over
        if (currentQuestion != null)
        {
            // Question text in the scene = questionText in scriptableobject
            questionText.text = currentQuestion.questionText;

            
            for (int i = 0; i < currentQuestion.answer.Length ; ++i)
            {
                // Buttons text = answer text in scriptableobject
                answersText[i].text = currentQuestion.answer[i];
            }
        }
        else
        {
            //Eror or end;
        }
    }

    // Randomly shuffles the order of the questions
    private void MixOrder()
    {
        questionsDatas.questionintheEpisode = questionsDatas.questionintheEpisode.OrderBy(i => Random.value).ToList();
    }

    // You should give this function to the answer buttons with the answer IDs.
    public void CheckAnswer(int _givenAnswer)
    {
        if (_givenAnswer == currentQuestion.corretAnswerID)
        {
            //True Answer
            print("True Answer");
        }
        else
        {
            //False Answer
            print("False Answer");
        }
    }
}
