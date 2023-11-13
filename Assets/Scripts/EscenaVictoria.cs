using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaVictoria : MonoBehaviour
{
    public TextMeshProUGUI puntosText;
    public float tiempoEspera = 5.0f; // Tiempo en segundos antes de cambiar de escena

    void Start()
    {
        float puntos = PlayerPrefs.GetFloat("Puntos", 0);
        puntosText.text = "Cantidad de puntos: " + puntos.ToString();
        //puntosText.text = "Cantidad de puntos: " + PlayerPrefs.GetFloat("Puntos", 0).ToString(); // Muestra los puntos guardados
        StartCoroutine(CambiarEscenaDespuesDeEspera(tiempoEspera));
    }

    IEnumerator CambiarEscenaDespuesDeEspera(float tiempo)
    {
        yield return new WaitForSeconds(tiempo); // Espera el tiempo especificado
        CambiarEscena();
    }

    void CambiarEscena()
    {
        SceneManager.LoadScene("Wireframe2"); // Reemplaza "NombreDeTuEscenaPuntos" con el nombre de la escena con los puntos
    }
}
