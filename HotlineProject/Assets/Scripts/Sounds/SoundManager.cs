using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Dictionary<string, AudioClip> soundDictionary;
    internal object isPlaying;
    private AudioSource audioSource;

    void Start()
    {
        // Inicializa el diccionario
        soundDictionary = new Dictionary<string, AudioClip>();

        // Agrega sonidos al diccionario
        soundDictionary.Add("poker_sound", Resources.Load<AudioClip>("poker_sound"));
        soundDictionary.Add("ok_sound", Resources.Load<AudioClip>("ok_sound"));
        soundDictionary.Add("AgarraLas2Cartas", Resources.Load<AudioClip>("AgarraLas2Cartas"));
        soundDictionary.Add("BuscaLas2Cartas", Resources.Load<AudioClip>("BuscaLas2Cartas"));
        soundDictionary.Add("Completado", Resources.Load<AudioClip>("Completado"));
        soundDictionary.Add("Depositar", Resources.Load<AudioClip>("Depositar"));
        soundDictionary.Add("Distraer", Resources.Load<AudioClip>("Distraer"));

        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // reproduce un sonido por su nombre
    public void ReproducirSonido(string nombreSonido)
    {
        if (soundDictionary.ContainsKey(nombreSonido))
        {
            audioSource.PlayOneShot(soundDictionary[nombreSonido]);
            Debug.Log("se reprodujo el sonido");
        }
        else
        {
            Debug.LogWarning("El sonido " + nombreSonido + " no está en el diccionario.");
        }
    }
}

