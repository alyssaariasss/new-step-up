using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private QuizUI quizUI;

    [SerializeField]
    private List<Question> questions;
    private Question currentQues;

    [SerializeField]
    private string NextScene;

    private int val;

    public Text ScoreText;
    public Text NumTitle;

    public int quesnum = 0;
    public int score;

    void Start()
    {
        NumTitle.text = "LEVEL " + quesnum;
        GenerateQuestion();
    }

    // randomize questions
    void GenerateQuestion()
    {
        if (questions.Count > 0)
        {
            quesnum += 1;
            NumTitle.text = "LEVEL " + quesnum;

            val = Random.Range(0, questions.Count);
            ScoreText.text = score.ToString();
            currentQues = questions[val];

            quizUI.SetQuestion(currentQues);
        }
        else
        {
            ScoreText.text = score.ToString();
            LevelComplete();
        }
    }

    // check if correct answer
    public bool Answer(string isAnswered)
    {
        bool correctAns = false;

        if (isAnswered == currentQues.correctAns)
        {
            correctAns = true;
            score += 1;
            questions.RemoveAt(val);
        }
        else
        {
            questions.RemoveAt(val);
        }

        Invoke("GenerateQuestion", 0.5f);

        return correctAns;
    }

    // switch to next scene
    void LevelComplete()
    {
        SceneManager.LoadScene(sceneName: NextScene);
    }
}

[System.Serializable]

// initializes question
public class Question
{
    public string questionText;
    public List<string> choices;
    public string correctAns;
    public QuestionType questionType;
    public Sprite questionImg;
}

[System.Serializable]

// additional; handle image type question at level 5
public enum QuestionType
{
    TEXT,
    IMAGE
}
