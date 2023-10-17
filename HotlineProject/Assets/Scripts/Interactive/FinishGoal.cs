using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGoal : MonoBehaviour
{
    // Start is called before the first frame update
    private EscenasManager sceneM;
    
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
            sceneM.ReturnToMaimMenu();
            Destroy(this.gameObject);
        }
    }
}
