using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelSelector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button[] levelButtons;
    [SerializeField] private GameDataController datacontroller;
    [SerializeField] private StaminaSistem staminaSistem;
    void Start()
    {
        datacontroller = FindObjectOfType<GameDataController>();
        staminaSistem = FindObjectOfType<StaminaSistem>();

        for (int i = 1; i < 5; i++)
        {
            levelButtons[i].onClick.AddListener(staminaSistem.UseStamina);
        }
    }

    private void Update() {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if(i > datacontroller.newLevelsCompleted)
                levelButtons[i].interactable = false;
        }
    }

}
