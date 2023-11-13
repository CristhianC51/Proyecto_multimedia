using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PreguntasModo1 : MonoBehaviour
{
    public Question[] questions;

    public Button[] answerButtons;
    public TextMeshProUGUI questionText;

    int currentQuestionIndex = 0;

    private void Start()
    {
        ShowQuestion();
    }

    void ShowQuestion()
    {
        Question question = questions[currentQuestionIndex];
        questionText.text = question.questionText;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i];
            button.GetComponentInChildren<TextMeshProUGUI>().text = question.answers[i];

            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => OnAnswerSelected(i == question.correctAnswerIndex));
        }
    }

    void OnAnswerSelected(bool correct)
    {
        if (correct)
        {
            currentQuestionIndex++;
            if (currentQuestionIndex >= questions.Length)
            {
                FinishQuiz();
            }
            else
            {
                ShowQuestion();
            }
        }
        else
        {
            // Handle incorrect
        }
    }
    void FinishQuiz()
    {
        // Quiz completed
        Debug.Log("Quiz finalizado!");
    }
}

[System.Serializable]
public class Question
{
    public string questionText;
    public string[] answers;
    public int correctAnswerIndex;
}
