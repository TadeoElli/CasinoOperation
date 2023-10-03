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
    }

    private void SaveGame()
    {
        string json = JsonUtility.ToJson(_DataSaved); //transforma esta clase de archivo a Json
        File.WriteAllText(path, json);
    }

    private void LoadGame()
    {
        string json = File.ReadAllText(path); //Busca y Encuentra el archivo creado por el Save
        JsonUtility.FromJsonOverwrite(json, _DataSaved); // Sobrescribe los datos guardados
    }

    public void DeleteSavedData()
    {
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("Datos guardados eliminados.");
        }
        else
        {
            Debug.LogWarning("No se encontraron datos guardados para eliminar.");
        }
    }
}
