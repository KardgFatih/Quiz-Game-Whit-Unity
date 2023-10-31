using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data;
using System.Linq;

public class QuestionConfig : MonoBehaviour
{   
    [SerializeField] private QuestionsDatas questionsDatas; 
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

    public void ConfigNextQuestion()
    {
        if (questionsDatas.questionintheEpisode[currenntQuestionID] != null)
        {
            // Sahnedeki = textimiz scriptabledeki text
            questionText.text = questionsDatas.questionintheEpisode[currenntQuestionID].questionText;

            // s
            for (int i = 0; i < questionsDatas.questionintheEpisode[currenntQuestionID].answer.Length ; ++i)
            {
                answersText[i].text = questionsDatas.questionintheEpisode[currenntQuestionID].answer[i];
            }
        }
        else
        {
            //Eror or end;
        }
    }

    public void MixOrder()
    {
        questionsDatas.questionintheEpisode = questionsDatas.questionintheEpisode.OrderBy(i => Random.value).ToList();
    }
}
