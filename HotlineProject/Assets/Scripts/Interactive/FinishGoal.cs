using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGoal : MonoBehaviour
{
    // Start is called before the first frame update
    private EscenasManager sceneM;
    [SerializeField] private int actualLevel;
    [SerializeField] private GameDataController datacontroller;
    
    void Start()
    {
        sceneM = GetComponent<EscenasManager>();
        datacontroller = FindObjectOfType<GameDataController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" && GameManager.Instance.midGoal == null)
        {
            //Debug.Log("FinishLevel");
            if(actualLevel == 1)
            {
                datacontroller.newLevelsCompleted = actualLevel;
                datacontroller.SaveData();
            }
            else if(datacontroller.newLevelsCompleted < actualLevel)
            {
                datacontroller.newLevelsCompleted = actualLevel;
                datacontroller.SaveData();
            }
            sceneM.ReturnToMaimMenu();
            Destroy(this.gameObject);
        }
    }
}
