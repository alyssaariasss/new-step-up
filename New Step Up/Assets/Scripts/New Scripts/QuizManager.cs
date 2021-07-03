using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private QuizUI quizUI;
    [SerializeField] private float timeLimit = 30f;

    [SerializeField]
    private List<Question> questions;
    private Question currentQues;
    private int scoreCount = 0;
    private float currentTime;
    private int lifeRemaining = 3;

    private GameStatus gameStatus = GameStatus.Next;
    public GameStatus GameStatus { get { return gameStatus; } }

    [SerializeField]
    private string NextScene;

    private int val;

    public Text ScoreText;
    public Text NumTitle;

    public int quesnum = 0;
    public int score;

    public void Start()
    {
        scoreCount = 0;
        currentTime = timeLimit;
        lifeRemaining = 3;

        NumTitle.text = "LEVEL " + quesnum;
        GenerateQuestion();
        gameStatus = GameStatus.Playing;
    }

    // randomize questions
    void GenerateQuestion()
    {
        if (questions.Count > 0)
        {
            quesnum += 1;
            NumTitle.text = "LEVEL " + quesnum;

            int val = UnityEngine.Random.Range(0, questions.Count);
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
    private void Update()
    {
        if (gameStatus == GameStatus.Playing)
        {
            currentTime -= Time.deltaTime;
            SetTimer(currentTime);


        }
    }


    private void SetTimer(float value)
    {

        TimeSpan time = TimeSpan.FromSeconds(value);
        quizUI.TimerText.text = time.ToString("mm':'ss");

        if (currentTime <= 0)
        {
            gameStatus = GameStatus.Next;
            SceneManager.LoadScene(20);
        }
    }



    // check if correct answer
    public bool Answer(string isAnswered)
    {
        bool correctAns = false;

        if (isAnswered == currentQues.correctAns)
        {
            correctAns = true;
            scoreCount += 20;
            quizUI.ScoreText.text = "Score:" + scoreCount;
            questions.RemoveAt(val);
        }
        else
        {
            lifeRemaining--;
            quizUI.ReduceLife(lifeRemaining);
            questions.RemoveAt(val);

            if (lifeRemaining <= 0)
            {
                gameStatus = GameStatus.Next;
                SceneManager.LoadScene(20);
            }
        }

        if (gameStatus == GameStatus.Playing)
        {
            if (questions.Count > 0)
            {
                Invoke("GenerateQuestion", 0.5f);
            }
            else
            {
                gameStatus = GameStatus.Playing;
                SceneManager.LoadScene(sceneName: NextScene);
            }

        }
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

[System.Serializable]
public enum GameStatus
{
    Next,
    Playing
}
