using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data;
using System.Linq;
using UnityEngine.UI;
using System.ComponentModel;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using Unity.VisualScripting;
using UnityEditor.PackageManager;

public class QuestionConfig : MonoBehaviour
{
    [SerializeField] GameObject soundManager;
    private AudioMng audioMng;

    [SerializeField] private QuestionsDatas questionsDatas; // Scriptable object
    [SerializeField] private Questions currentQuestion; // Class of scriptable object 
    [SerializeField] private TextMeshProUGUI questionText; // Text in which the question is written
    //ID = 0 => The text of the answer_1 button, ID = 1 => The text of the answer_2 button ...
    [SerializeField] private Button[] answerButton;
    [SerializeField] private TextMeshProUGUI[] answersText;// Text in which the answers is written

    [SerializeField] private GameObject currectObject, worseObject; // Visual effects to show whether the answer is right or wrong
    [SerializeField] private GameObject finishPanel;

    // questions[selectedID].QuestionsDatas = questions[selectedID].QuestionsDatas.OrderBy(i => Random.value).ToList();
    private int currenntQuestionID;
    private bool canAnswer = true;

    //There should be an object tagged "SoundManager" in the scene and an AudioMng component inside it.
    void Start()
    {
        for (int i = 0; i < answerButton.Length; i++)
        {
            answersText[i] = answerButton[i].GetComponentInChildren<TextMeshProUGUI>();
        }

        soundManager = GameObject.FindGameObjectWithTag("SoundManager"); // Finds the object tagged "SoundManager" in the scene
        audioMng = soundManager.GetComponent<AudioMng>(); // Gets the Audio Mng component from within that object

        MixOrder(); 
        ConfigQuestion(); // Prints the first question on the screen
    }

    void NextQuestion() // Moves to next question
    {
        if (questionsDatas.questionList.Count-1 != currenntQuestionID ) //If there is still a question in the list, increase the currentQuestionID by 1
        {
            currenntQuestionID += 1;
            ConfigQuestion(); // Prints the current question on the screen
        }
        else // if not it means it has reached the end, activates the end panel
            finishPanel.SetActive(true); 
    }

    private void ConfigQuestion()
    {
        currentQuestion = questionsDatas.questionList[currenntQuestionID]; // currentQuestion synchronizes corresponding questions from the list

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
    }

    // Randomly shuffles the order of the questions
    private void MixOrder()
    {
        questionsDatas.questionList = questionsDatas.questionList.OrderBy(i => Random.value).ToList();
    }

    //Activates the right object or the wrong object, waits for a while, deactivates the object and brings up a new question
    IEnumerator CorrectOrNotPng(float delay,GameObject obj) 
    {
        for (int i = 0; i < answerButton.Length; i++) // Prevents you from answering follow-up questions before they come up
            answerButton[i].interactable = false; // Disables answering the question

        obj.SetActive(true);
        yield return new WaitForSeconds(delay); // waits until delay
        obj.SetActive(false);
        NextQuestion(); // Moves to next question

        for (int i = 0; i < answerButton.Length; i++)
            answerButton[i].interactable = true; // Enables answering the question
    }

    // You should give this function to the answer buttons with the answer IDs.
    // To use this function, you must assign it to the answer buttons and specify the answerindex(_givenAnswer) for each answer button.
    public void GetAnswer(int _givenAnswer)
    {
        if (_givenAnswer == currentQuestion.corretAnswerID)
        {
            //True Answer
            audioMng.PlayCorrectSoundEfect();// Play correct sound efect
            print("True Answer");
            StartCoroutine(CorrectOrNotPng(0.9f, currectObject));
        }
        else
        {
            //False Answer
            audioMng.PlayWrongtSoundEfect(); // Play wrong sound efect
            print("False Answer");
            StartCoroutine(CorrectOrNotPng(0.9f, worseObject));
        }
    }
}
