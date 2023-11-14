using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PreguntasModo1 : MonoBehaviour
{
    public Pregunta[] Preguntas;
    public Button[] answerButtons;
    public TextMeshProUGUI PreguntaText;
    public TextMeshProUGUI errorText;
    public TextMeshProUGUI pointsText; // TextMeshProUGUI para mostrar los puntos

    public AudioSource musicSource;
    public AudioClip nuevaMusica;
    public string nombreNuevaEscena;

    int currentPreguntaIndex = 0;
    float points = 0; // Variable para rastrear los puntos

    private void Start()
    {
        ShowPregunta();
        UpdatePointsDisplay();
    }

    void ShowPregunta()
    {
        if (currentPreguntaIndex < Preguntas.Length)
        {
            Pregunta Pregunta = Preguntas[currentPreguntaIndex];
            PreguntaText.text = Pregunta.PreguntaText;

            for (int i = 0; i < answerButtons.Length; i++)
            {
                int answerIndex = i;
                Button button = answerButtons[i];
                button.GetComponentInChildren<TextMeshProUGUI>().text = Pregunta.answers[i];

                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => OnAnswerSelected(answerIndex == Pregunta.correctAnswerIndex));
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
            currentPreguntaIndex++;
            ShowPregunta();
            errorText.text = "";
        }
        else
        {
            points -= 0.5f; // Restar 0.5 puntos por respuesta incorrecta
            errorText.text = "Error: �Te has equivocado?";
        }
        UpdatePointsDisplay();
    }

    void FinishQuiz()
    {
        Debug.Log("�Quiz finalizado!");
        Debug.Log("Puntos: " + points);
        PlayerPrefs.SetFloat("Puntos", points);// Muestra los puntos en la consola
        CambiarMusicaYEscena();
        SceneManager.LoadScene("Wireframe8");
    }

    void UpdatePointsDisplay()
    {
        pointsText.text = "Puntos: " + points.ToString(); // Actualiza el display de puntos
    }

    public void CambiarMusicaYEscena()
    {
        if (musicSource != null && nuevaMusica != null)
        {
            musicSource.clip = nuevaMusica;
            musicSource.Play();
        }

        if (!string.IsNullOrEmpty(nombreNuevaEscena))
        {
            SceneManager.LoadScene(nombreNuevaEscena);
        }
    }
}

[System.Serializable]
public class Pregunta
{
    public string PreguntaText;
    public string[] answers;
    public int correctAnswerIndex;
}