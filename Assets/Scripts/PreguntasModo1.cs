using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PreguntasModo1 : MonoBehaviour
{
    public Question[] questions;
    public Button[] answerButtons;
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI errorText;
    public TextMeshProUGUI pointsText; // TextMeshProUGUI para mostrar los puntos

    int currentQuestionIndex = 0;
    float points = 0; // Variable para rastrear los puntos

    private void Start()
    {
        ShowQuestion();
        UpdatePointsDisplay();
    }

    void ShowQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            Question question = questions[currentQuestionIndex];
            questionText.text = question.questionText;

            for (int i = 0; i < answerButtons.Length; i++)
            {
                int answerIndex = i;
                Button button = answerButtons[i];
                button.GetComponentInChildren<TextMeshProUGUI>().text = question.answers[i];

                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => OnAnswerSelected(answerIndex == question.correctAnswerIndex));
            }
        }
        else
        {
            FinishQuiz();
        }
    }

    void OnAnswerSelected(bool correct)
    {
        if (correct)
        {
            points++; // Sumar un punto por respuesta correcta
            currentQuestionIndex++;
            ShowQuestion();
            errorText.text = "";
        }
        else
        {
            points -= 0.5f; // Restar 0.5 puntos por respuesta incorrecta
            errorText.text = "Error: ¿Te has equivocado?";
        }
        UpdatePointsDisplay();
    }

    void FinishQuiz()
    {
        Debug.Log("¡Quiz finalizado!");
        Debug.Log("Puntos: " + points);
        PlayerPrefs.SetFloat("Puntos", points);// Muestra los puntos en la consola
        SceneManager.LoadScene("Wireframe8");
    }

    void UpdatePointsDisplay()
    {
        pointsText.text = "Puntos: " + points.ToString(); // Actualiza el display de puntos
    }
}

[System.Serializable]
public class Question
{
    public string questionText;
    public string[] answers;
    public int correctAnswerIndex;
}