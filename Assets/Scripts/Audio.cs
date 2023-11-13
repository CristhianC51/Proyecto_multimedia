using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip nuevaMusica;
    public string nombreNuevaEscena;

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
