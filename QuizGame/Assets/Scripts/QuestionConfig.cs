using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data;
using System.Linq;
using UnityEngine.UI;

public class QuestionConfig : MonoBehaviour
{
    [SerializeField] GameObject soundManager;
    private AudioMng audioMng;

    [SerializeField] private QuestionsDatas questionsDatas;
    [SerializeField] private Questions currentQuestion;
    [SerializeField] private TextMeshProUGUI questionText;
    //ID = 0 => The text of the answer_1 button, ID = 1 => The text of the answer_2 button ...
    [SerializeField] private TextMeshProUGUI[] answersText;

    [SerializeField] private GameObject currectObject, worseObject;
    [SerializeField] private GameObject finishPanel;

    // questions[selectedID].QuestionsDatas = questions[selectedID].QuestionsDatas.OrderBy(i => Random.value).ToList();
    private int currenntQuestionID;

    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager");
        audioMng = soundManager.GetComponent<AudioMng>();

        MixOrder();
        ConfigQuestion();
    }

    void NextQuestion()
    {
        print(questionsDatas.questionintheEpisode.Count);
        if (questionsDatas.questionintheEpisode.Count-1 != currenntQuestionID )
        {
            currenntQuestionID += 1;
            ConfigQuestion();
        }
        else
            finishPanel.SetActive(true);
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

    IEnumerator CorrectOrNotPng(float delay,GameObject obj)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
        NextQuestion();
    }

    // You should give this function to the answer buttons with the answer IDs.
    public void GetAnswer(int _givenAnswer)
    {
        if (_givenAnswer == currentQuestion.corretAnswerID)
        {
            //True Answer
            audioMng.PlayCorrectSoundEfect();
            print("True Answer");
            StartCoroutine(CorrectOrNotPng(1f, currectObject));
        }
        else
        {
            //False Answer
            audioMng.PlayWrongtSoundEfect();
            print("False Answer");
            StartCoroutine(CorrectOrNotPng(1f, worseObject));
        }
    }
}
