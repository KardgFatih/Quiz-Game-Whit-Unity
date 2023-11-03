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
        ConfigNextQuestion();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            currenntQuestionID += 1;
            ConfigNextQuestion();
        }
    }

    private void ConfigNextQuestion()
    {
        currentQuestion = questionsDatas.questionintheEpisode[currenntQuestionID];

        if (currentQuestion != null)
        {
            // Sahnedeki = textimiz scriptabledeki text
            questionText.text = currentQuestion.questionText;

            // s
            for (int i = 0; i < currentQuestion.answer.Length ; ++i)
            {
                answersText[i].text = currentQuestion.answer[i];
            }
        }
        else
        {
            //Eror or end;
        }
    }

    private void MixOrder()
    {
        questionsDatas.questionintheEpisode = questionsDatas.questionintheEpisode.OrderBy(i => Random.value).ToList();
    }

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
