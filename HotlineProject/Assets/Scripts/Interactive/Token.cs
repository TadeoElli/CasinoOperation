using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            GameManager.Instance.DecreaseToken();
            Destroy(this.gameObject);
        }
    }
}
