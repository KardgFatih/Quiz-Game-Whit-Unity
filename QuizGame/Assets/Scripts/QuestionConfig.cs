using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data;
using System.Linq;
using UnityEngine.UI;

public class QuestionConfig : MonoBehaviour
{   
    [SerializeField] private QuestionsDatas questionsDatas;
    [SerializeField] private Questions currentQuestion;
    [SerializeField] private TextMeshProUGUI questionText;
    //ID = 0 => The text of the answer_1 button, ID = 1 => The text of the answer_2 button ...
    [SerializeField] private TextMeshProUGUI[] answersText;

    [SerializeField] private GameObject currectObject, worseObject;

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
            StartCoroutine(NextQuestion(0.9f));
        }
    }
    void NextQuestion()
    {
        currenntQuestionID += 1;
        ConfigQuestion();
    }

    IEnumerator NextQuestion(float delay)
    {
        yield return new WaitForSeconds(delay);
        currenntQuestionID += 1;
        ConfigQuestion();
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

    float timer;
    IEnumerator CorrectOrNot(float delay,GameObject obj)
    {
        //obj.
        //timer = 0;
       /* while (true)
        {
            timer += Time.deltaTime;
        }*/
        

        yield return new WaitForSeconds(delay/2);
        print("sa");
        for (int i = 0; i > 0; --i)
        {

        }
        obj.SetActive(false);
        yield return new WaitForSeconds(delay / 2);
        NextQuestion();
    }

    IEnumerator WorseAnswer(float delay,GameObject obj)
    {
        yield return new WaitForSeconds(delay);
        currenntQuestionID += 1;
        ConfigQuestion();
    }

    // You should give this function to the answer buttons with the answer IDs.
    public void GetAnswer(int _givenAnswer)
    {
        if (_givenAnswer == currentQuestion.corretAnswerID)
        {
            //True Answer
            print("True Answer");
            StartCoroutine(CorrectOrNot(1f, currectObject));
        }
        else
        {
            //False Answer
            print("False Answer");
            StartCoroutine(CorrectOrNot(1f, worseObject));
        }
    }
}
