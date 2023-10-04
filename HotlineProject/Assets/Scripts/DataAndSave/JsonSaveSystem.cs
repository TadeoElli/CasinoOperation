using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //Crea o busca una direccion de carpeta para guardar el archivo JSON - path

public class JsonSaveSystem : MonoBehaviour
{
    [SerializeField] DataSaved _DataSaved = new DataSaved();
    string path;

    public void Awake()
    {
        path = Application.persistentDataPath + "/SaveData.json"; // Lo guarda en una carpeta existente en android
        Debug.Log(path);
    }

    private void SaveGame()
    {
        string json = JsonUtility.ToJson(_DataSaved, true); //transforma esta clase de archivo a Json
        File.WriteAllText(path, json);
    }

    private void LoadGame()
    {
        string json = File.ReadAllText(path); //Busca y Encuentra el archivo creado por el Save
        JsonUtility.FromJsonOverwrite(json, _DataSaved); // Sobrescribe los datos guardados
    }
}
