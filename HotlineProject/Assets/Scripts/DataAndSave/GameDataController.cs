using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class GameDataController : MonoBehaviour
{
    public string save_file;
    public static GameDataController instance;
    public GameData gameData = new GameData();
    [SerializeField] private StaminaLevel staminaLevel;

    [SerializeField] public int newEnergy, newLevelsCompleted, newScoreTokens;
    [SerializeField] public bool[] newTokens;
    


    private void Awake() {

        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        save_file = Application.persistentDataPath + "/gameData.json";
        Debug.Log(save_file);
        if(File.Exists(save_file))
        {
            LoadData();
            Debug.Log("The file was charged");
        }
        else
        {
            newEnergy = 3;
            for (int i = 0; i < 12; i++)
            {
                newTokens[i] = true;
            }
            SaveData();
        }
    }

    private void Update() {
        //staminaLevel.ActualizarUI();
    }

    public void LoadData()
    {
        if(File.Exists(save_file))
        {
            string content = File.ReadAllText(save_file);
            gameData = JsonUtility.FromJson<GameData>(content);
            newEnergy = gameData.energy;
            newLevelsCompleted = gameData.levelsCompleted;
            newTokens = gameData.tokens;
            newScoreTokens = gameData.tokenScore;
            staminaLevel.vidas = gameData.energy;
            Debug.Log(" "+ gameData.energy);
        }
        else
        {
            Debug.Log("The file dont exist");
        }
    }

    public void SaveData()
    {
        GameData newData = new GameData()
        {
            energy = newEnergy,
            levelsCompleted = newLevelsCompleted,
            tokens = newTokens,
            tokenScore = newScoreTokens
        };
        staminaLevel.vidas = newData.energy;
        string dataJSON = JsonUtility.ToJson(newData);

        File.WriteAllText(save_file, dataJSON);

        Debug.Log("File Saved");
    }
}

