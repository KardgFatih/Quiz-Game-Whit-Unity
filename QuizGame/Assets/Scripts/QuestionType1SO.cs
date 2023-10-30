using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This question type is for multiple choice questions
[CreateAssetMenu(fileName = "Question_Type_1", menuName = "Question/Question_Type_1")]
public class QuestionType1SO : ScriptableObject
{
    public string questionText;

    public string[] answers; // List of your answer // The ID of the first answer = 0 , The ID of the second answer is 1 , The id of the third answer is 2...
    public int correctAnswerId;
}
