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
    private int highscore = 0;
    private float currentTime;
    private int lifeRemaining = 3;

    private GameStatus gameStatus = GameStatus.Next;
    public GameStatus GameStatus { get { return gameStatus; } }

    [SerializeField]
    private string NextScene;

    private int val;

    public Text NumTitle;

    public int quesnum = 0;

    public void Start()
    {
        if (PlayerPrefs.HasKey("Score") || PlayerPrefs.HasKey("Highscore"))
        {
            LoadScore();
            highscore = PlayerPrefs.GetInt("Highscore");
        }
        else
        {
            PlayerPrefs.SetInt("Score", 0);
            PlayerPrefs.SetInt("Highscore", 0);
        }

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

            val = UnityEngine.Random.Range(0, questions.Count);
            currentQues = questions[val];

            quizUI.SetQuestion(currentQues);
        }
        else
        {
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
            UpdateHighscore();

            scoreCount = 0;
            SaveScore();

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
            AddScore();
            questions.RemoveAt(val);
        }
        else
        {
            lifeRemaining--;
            quizUI.ReduceLife(lifeRemaining);
            questions.RemoveAt(val);

            if (lifeRemaining <= 0)
            {
                UpdateHighscore();

                scoreCount = 0;
                SaveScore();

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

    private void AddScore()
    {
        scoreCount += 20;
        SaveScore();
        UpdateHighscore();
        quizUI.ScoreText.text = "Score:" + scoreCount;
    }

    private void UpdateHighscore()
    {
        if (scoreCount > highscore)
        {
            highscore = scoreCount;
            PlayerPrefs.SetInt("Highscore", highscore);
        }
    }

    private void LoadScore()
    {
        scoreCount = PlayerPrefs.GetInt("Score");
        quizUI.ScoreText.text = "Score:" + scoreCount;
    }

    private void SaveScore()
    {
        PlayerPrefs.SetInt("Score", scoreCount);
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
