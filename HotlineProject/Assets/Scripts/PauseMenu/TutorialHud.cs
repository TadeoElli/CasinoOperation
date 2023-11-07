using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHud : MonoBehaviour
{
    [SerializeField] private GameObject[] allInstructions;
    [SerializeField] private int tutorialStage = 1;

    [SerializeField] private GameObject card1, card2;
    private Player player;
    private Enemy enemy;

    void Start()
    {
        player = FindObjectOfType<Player>();
        enemy = FindObjectOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(tutorialStage)
        {
            case 1:
                allInstructions[0].SetActive(true);
                if(player.agent.hasPath)
                {
                    tutorialStage = 2;
                }
                break;
            case 2:
                allInstructions[0].SetActive(false);
                allInstructions[1].SetActive(true);
                allInstructions[2].SetActive(true);
                if((Vector3.Distance(player.transform.position,card1.transform.position) < 10 || (Vector3.Distance(player.transform.position,card2.transform.position) < 10)))
                {
                    tutorialStage = 3;
                }
                break;
            case 3:
                allInstructions[2].SetActive(false);
                allInstructions[3].SetActive(true);
                allInstructions[4].SetActive(true);
                allInstructions[7].SetActive(true);
                if(GameManager.Instance.cardsInLevel == 0)
                {
                    tutorialStage = 4;
                }
                break;
            case 4:
                allInstructions[4].SetActive(false);
                allInstructions[5].SetActive(true);
                allInstructions[9].SetActive(true);
                if(GameManager.Instance.midGoal == null)
                {
                    tutorialStage = 5;
                }
                break;
            case 5:
                allInstructions[9].SetActive(false);
                allInstructions[10].SetActive(true);
                allInstructions[11].SetActive(true);
                break;
            default:
                break;
        }
        if((allInstructions[4].activeSelf || allInstructions[5].activeSelf ) && enemy.isAlert)
        {
            allInstructions[4].SetActive(false);
            allInstructions[5].SetActive(false);
            allInstructions[6].SetActive(true);
        }
        if(allInstructions[7].activeSelf && player._model.hasThrow)
        {
            allInstructions[7].SetActive(false);
            allInstructions[8].SetActive(true);
        }
    }
}
