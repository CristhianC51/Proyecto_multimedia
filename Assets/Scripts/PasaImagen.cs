using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseImageBasedOnQuestion : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI[] imageDescriptionTexts;
    public Image[] imageComponents;
    public string[] questions;
    public string[] imageDescriptions;
    public Sprite[] images;
    public int[] correctAnswerIndices; // Índices de las respuestas correctas
    private int currentQuestionIndex = 0;

    private void Start()
    {
        ShowQuestionAndImages();
    }

    public void SelectAnswer(int answerIndex)
    {
        if (correctAnswerIndices[currentQuestionIndex] == answerIndex)
        {
        }
        else
        {
            // Respuesta incorrecta, muestra un mensaje de error o toma la acción adecuada.
            Debug.Log("Respuesta incorrecta. Inténtalo de nuevo.");
        }
    }

    private void ShowQuestionAndImages()
    {
        if (questions.Length > 0)
        {
            questionText.text = questions[currentQuestionIndex];
            for (int i = 0; i < imageDescriptionTexts.Length; i++)
            {
                imageDescriptionTexts[i].text = imageDescriptions[currentQuestionIndex * 3 + i];
                imageComponents[i].sprite = images[currentQuestionIndex * 3 + i];
            }
        }
    }
}


