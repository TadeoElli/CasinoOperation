using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int tokenId;

    [SerializeField] private GameDataController datacontroller;
    void Start()
    {
        datacontroller = FindObjectOfType<GameDataController>();
        if(!datacontroller.newTokens[tokenId])
            this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            datacontroller.newTokens[tokenId] = false;
            datacontroller.newScoreTokens++;
            datacontroller.SaveData();
            Destroy(this.gameObject);
        }
    }
}
