using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelSelector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button[] levelButtons;
    void Start()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if(i > GameManager.Instance.levelsCompleted)
                levelButtons[i].interactable = false;
        }
    }

}
