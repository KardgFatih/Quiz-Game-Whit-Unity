using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "Questions")]
public class QuestionsDatas : ScriptableObject
{
    public List<Questions> questionList;
}

[Serializable]
public class Questions
{
    [field: SerializeField] public string questionText { get; private set; }
    [field: SerializeField] public string[] answer { get; private set; }
    [field: SerializeField] public int corretAnswerID { get; private set; }
}