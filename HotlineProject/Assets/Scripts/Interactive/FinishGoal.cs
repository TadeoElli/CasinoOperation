using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGoal : MonoBehaviour
{
    // Start is called before the first frame update
    private EscenasManager sceneM;
    [SerializeField] private int actualLevel;
    
    void Start()
    {
        sceneM = GetComponent<EscenasManager>();
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
                GameManager.Instance.levelsCompleted = actualLevel;
            }
            else if(GameManager.Instance.levelsCompleted < actualLevel)
            {
                GameManager.Instance.levelsCompleted = actualLevel;
            }
            sceneM.ReturnToMaimMenu();
            Destroy(this.gameObject);
        }
    }
}
