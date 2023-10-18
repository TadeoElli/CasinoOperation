using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class GameDataController : MonoBehaviour
{
    public string save_file;
    private int newEnergy = 0;
    public GameData gameData = new GameData();
    [SerializeField] private StaminaLevel staminaLevel;
    


    private void Awake() {

        save_file = Application.persistentDataPath + "/gameData.json";
        Debug.Log(save_file);
        if(File.Exists(save_file))
        {
            LoadData();
            Debug.Log("The file was charged");
        }
        else
        {
            SaveData(0);
        }
    }

    private void Update() {
        staminaLevel.ActualizarUI();
    }

    public void LoadData()
    {
        if(File.Exists(save_file))
        {
            string content = File.ReadAllText(save_file);
            gameData = JsonUtility.FromJson<GameData>(content);
            staminaLevel.vidas = gameData.energy;
            Debug.Log(" "+ gameData.energy);
        }
        else
        {
            Debug.Log("The file dont exist");
        }
    }

    public void SaveData(int i)
    {
        GameData newData = new GameData()
        {
            energy = i
        };

        string dataJSON = JsonUtility.ToJson(newData);

        File.WriteAllText(save_file, dataJSON);

        Debug.Log("File Saved");
    }
}

