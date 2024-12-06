using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionManager> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject GOPanel;
    public GameObject QuizPanel;

    public Image QuestionImg;
    public Text ScoreTxt;
    public Text lastScoreTxt;
    public int lastscore;

    int totalquestion = 0;
    public int score;
    public int lastScore;

    public Button buttonA;
    public Button buttonB;
    public Button buttonC;
    public Button buttonD;

    private void Start()
    {
        totalquestion = QnA.Count;
        generateQuestion();
        GOPanel.SetActive(false);
    }

    void GameOver()
    {
        QuizPanel.SetActive(false);
        GOPanel.SetActive(true);
        lastScoreTxt.text = lastScore + "/" + 25 * 4;
    }

    public void correct()
    {
        score += 4;
        lastScore += 4;
        ScoreTxt.text = score + "";
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());
    }
    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());
    }
    IEnumerator WaitForNext()
    {
        buttonA.interactable = false;
        buttonB.interactable = false;
        buttonC.interactable = false;
        buttonD.interactable = false;
        yield return new WaitForSeconds(1);
        generateQuestion();
        buttonA.interactable = true;
        buttonB.interactable = true;
        buttonC.interactable = true;
        buttonD.interactable = true;
    }
    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Answer>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
            options[i].GetComponent<Image>().color = options[i].GetComponent<Answer>().startColor;

            if (QnA[currentQuestion].CorrectAnswers == i + 1)
            {
                options[i].GetComponent<Answer>().isCorrect = true;
            }
        }
    }
    void generateQuestion()
    {
        if (QnA.Count > 15)
        {

            currentQuestion = Random.Range(0, QnA.Count);
            QuestionImg.sprite = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("soal e entek");
            GameOver();
        }
    }
}