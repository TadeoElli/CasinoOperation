using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour 
{
    // Start is called before the first frame update
    [SerializeField] private ObjectivePointer objPointer;
    void Start()
    {
        objPointer = FindObjectOfType<ObjectivePointer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            objPointer.cardObjective.Remove(this.gameObject);
            objPointer.minDistance = 200f;
            GameManager.Instance.DecreaseCard();
            Destroy(this.gameObject);
        }
    }
}
