using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI preguntaText;
    public Button botonVerdadero;
    public Button botonFalso;
    public TextMeshProUGUI puntosText; // Para mostrar los puntos
    public TextMeshProUGUI mensajeError; // Para mostrar el mensaje de error

    // Define una estructura para representar la pregunta y su respuesta
    [System.Serializable]
    public struct PreguntaRespuesta
    {
        public string pregunta;
        public bool respuesta;
    }

    public PreguntaRespuesta[] preguntasYrespuestas;

    private float puntos = 0; // Cambiado a float para permitir la resta de 0.5

    private int preguntaActual = 0;

    void Start()
    {
        MostrarPregunta();
        botonVerdadero.onClick.AddListener(() => Responder(true));
        botonFalso.onClick.AddListener(() => Responder(false));
        ActualizarPuntosTexto();
        OcultarMensajeError(); // Inicialmente oculta el mensaje de error
    }

    void MostrarPregunta()
    {
        preguntaText.text = preguntasYrespuestas[preguntaActual].pregunta;
    }

    void Responder(bool respuestaUsuario)
    {
        if (respuestaUsuario == preguntasYrespuestas[preguntaActual].respuesta)
        {
            puntos += 1; // Sumar 1 punto si la respuesta es correcta
            OcultarMensajeError(); // Si acierta, oculta el mensaje de error
        }
        else
        {
            puntos -= 0.5f; // Restar 0.5 puntos si la respuesta es incorrecta
            MostrarMensajeError("¡No acertaste!"); // Muestra el mensaje de error
        }

        SiguientePregunta();
        ActualizarPuntosTexto();
    }

    void SiguientePregunta()
    {
        preguntaActual++;

        if (preguntaActual < preguntasYrespuestas.Length)
        {
            MostrarPregunta();
        }
        else
        {
            GuardarPuntos();
            SceneManager.LoadScene("Wireframe8");
        }
    }

    void GuardarPuntos()
    {
        PlayerPrefs.SetFloat("Puntos", puntos);
    }

    void ActualizarPuntosTexto()
    {
        puntosText.text = "Puntos: " + puntos.ToString();
    }

    void MostrarMensajeError(string mensaje)
    {
        mensajeError.text = mensaje;
        mensajeError.gameObject.SetActive(true);
    }

    void OcultarMensajeError()
    {
        mensajeError.gameObject.SetActive(false);
    }
}
