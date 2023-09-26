using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    //public static GameManager Instance { get; private set; }
    private Player player;
    [SerializeField] private Vector3 StartPosition;
    [SerializeField] public int cardsInLevel;
    void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseCard()
    {
        cardsInLevel--;
        if(cardsInLevel == 0)
        {
            Debug.Log("FinishLevel");
        }
    }
    public void EndLevel()
    {
        player.transform.position = StartPosition;
        player.agent.SetDestination(StartPosition);
    }
}
