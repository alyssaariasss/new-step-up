using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private QuizManager quizManager;
    [SerializeField] private Text questionText;
    [SerializeField] private Image questionImage;
    [SerializeField] private List<Button> options;
    [SerializeField] private Color correctColor, wrongColor, defaultColor;

    private Question question;
    private bool isAnswered;

    void Awake()
    {
        for (int i = 0; i < options.Count; i++)
        {
            Button defButton = options[i];
            defButton.onClick.AddListener(() => OnClick(defButton));
        }
    }

    public void SetQuestion(Question question)
    {
        this.question = question;

        // switch case for image question type and text question type
        switch (question.questionType)
        {
            case QuestionType.TEXT:
                questionImage.transform.parent.gameObject.SetActive(false);
                break;
            case QuestionType.IMAGE:
                ImageHolder();
                questionImage.transform.gameObject.SetActive(true);
                questionImage.sprite = question.questionImg;
                break;
        }

        questionText.text = question.questionText;

        // randomize choices
        List<string> answerList = ShuffleList.ShuffleListItems<string>(question.choices);
    
        for (int i =0; i < options.Count; i++)
        {
            options[i].GetComponentInChildren<Text>().text = answerList[i];
            options[i].name = answerList[i];
            options[i].image.color = defaultColor;
        }

        isAnswered = false;
    }

    // handles questions with image at level 5
    void ImageHolder()
    {
        questionImage.transform.parent.gameObject.SetActive(true);
        questionImage.transform.gameObject.SetActive(false);
    }

    // change button color if correct or wrong
    private void OnClick(Button button)
    {
        if (!isAnswered)
        {
            isAnswered = true;
            bool isCorrect = quizManager.Answer(button.name);

            if (isCorrect)
            {
                button.image.color = correctColor;
            }
            else
            {
                button.image.color = wrongColor;
            }
        }
    }
}
