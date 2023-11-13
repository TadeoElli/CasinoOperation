using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonDeleteData : GameDataController
{
    public void DeleteSaveData()
    {
        if (Directory.Exists(Application.persistentDataPath))
        {
            Directory.Delete(Application.persistentDataPath, true); // Elimina la carpeta y sus archivos
            Debug.Log("Se elimin� la carpeta de datos.");
        }
    }
}
