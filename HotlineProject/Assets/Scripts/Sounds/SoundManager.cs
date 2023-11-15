using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Dictionary<string, AudioClip> soundDictionary;

    void Start()
    {
        // Inicializa el diccionario
        soundDictionary = new Dictionary<string, AudioClip>();

        // Agrega sonidos al diccionario
        soundDictionary.Add("poker_sound", Resources.Load<AudioClip>("poker_sound"));
        soundDictionary.Add("ok_sound", Resources.Load<AudioClip>("ok_sound"));
    }

    // reproduce un sonido por su nombre
    public void ReproducirSonido(string nombreSonido)
    {
        if (soundDictionary.ContainsKey(nombreSonido))
        {
            AudioSource.PlayClipAtPoint(soundDictionary[nombreSonido], Camera.main.transform.position);
            Debug.Log("se reprodujo el sonido");
        }
        else
        {
            Debug.LogWarning("El sonido " + nombreSonido + " no está en el diccionario.");
        }
    }
}
