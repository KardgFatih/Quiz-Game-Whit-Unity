using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // 0 = A, 1 = B, 2 = C...
    public QuestionConfig questionConfig;
    public void GetAnswer(int _answerIndex)
    {
        questionConfig.CheckAnswer(_answerIndex);
    }
}
