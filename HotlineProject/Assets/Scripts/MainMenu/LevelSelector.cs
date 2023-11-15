using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelSelector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button[] levelButtons;
    [SerializeField] private GameDataController datacontroller;
    void Start()
    {
        datacontroller = FindObjectOfType<GameDataController>();

        
    }

    private void Update() {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if(i > datacontroller.newLevelsCompleted)
                levelButtons[i].interactable = false;
        }
    }

}