using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionConfig : MonoBehaviour
{   
    [SerializeField] private RoundDatas roundDatas; 
    [SerializeField] private TextMeshProUGUI questionText;
    //ID = 0 => The text of the answer_1 button, ID = 1 => The text of the answer_2 button ...
    [SerializeField] private TextMeshProUGUI[] answersText; 

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ConfigNextQuestion()
    {
    }
}
