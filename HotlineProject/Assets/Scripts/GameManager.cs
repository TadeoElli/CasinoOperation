using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance { get; private set; }
    private Player player;
    [SerializeField] private GameObject finishGoal, goalPointer;
    [SerializeField] private Vector3 StartPosition;
    [SerializeField] public int cardsInLevel, tokensInLevel;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Hay mas de un gameManager");
        }
        player = FindObjectOfType<Player>();
    }

     void Start() {
        finishGoal.SetActive(false);
        goalPointer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(cardsInLevel == 0)
        {
            finishGoal.SetActive(true);
            goalPointer.SetActive(true);
        }
    }

    public void DecreaseCard()
    {
        cardsInLevel--; 
    }
    public void DecreaseToken()
    {
        tokensInLevel--; 
    }
    public void EndLevel()
    {
        player._controller.targetPosition = StartPosition;
        player.transform.position = StartPosition;
    }
}