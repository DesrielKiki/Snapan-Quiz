using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{

    public bool isCorrect = false;
    public QuizManager quizmanager;

    public Color startColor;

    private void Start()
    {
        startColor = GetComponent<Image>().color;
    }

    public void answer()
    {
        if (isCorrect)
        {
            GetComponent<Image>().color = Color.green;
            Debug.Log("jawabanmu benar");
            quizmanager.correct();
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            Debug.Log("jawabanmu salah");
            quizmanager.wrong();
        }
    }

}
