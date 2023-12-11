using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHud : MonoBehaviour
{
    [SerializeField] private GameObject[] allInstructions;
    [SerializeField] private int tutorialStage = 1;

    [SerializeField] private Card card1, card2;
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
                allInstructions[0].SetActive(true); // TapToMove
                if(player.agent.hasPath)
                {
                    tutorialStage = 2;
                    StartCoroutine(PauseGameForSeconds(2f));
                }
                break;
            case 2:
                allInstructions[0].SetActive(false); // TapToMove
                allInstructions[1].SetActive(true);  // TapToMoveComplete
                allInstructions[2].SetActive(true); //Find 2 Cards
                if((Vector3.Distance(player.transform.position,card1.transform.position) < 10 || (Vector3.Distance(player.transform.position,card2.transform.position) < 10)))
                {
                    tutorialStage = 3;
                    StartCoroutine(PauseGameForSeconds(2f));
                }
                break;
            case 3:
                allInstructions[2].SetActive(false); //Find 2 Cards
                allInstructions[3].SetActive(true);  //Find 2 Cards Complete
                allInstructions[4].SetActive(true); // Collect 2 Cards
                allInstructions[7].SetActive(true); // Use Skills
                if(GameManager.Instance.cardsInLevel == 0)
                {
                    tutorialStage = 4;
                    StartCoroutine(PauseGameForSeconds(2f));
                }
                break;
            case 4:
                allInstructions[4].SetActive(false); // Collect 2 Cards
                allInstructions[5].SetActive(true);  // Collect 2 Cards Complete
                allInstructions[9].SetActive(true);  // Go to de poker table
                if(GameManager.Instance.midGoal == null)
                {
                    tutorialStage = 5;
                    StartCoroutine(PauseGameForSeconds(2f));
                }
                break;
            case 5:
                allInstructions[9].SetActive(false); // Go to de poker table
                allInstructions[10].SetActive(true); // Go to de poker table complete
                allInstructions[11].SetActive(true); // Escape
                break;
            default:
                break;
        }
        if((allInstructions[4].activeSelf || allInstructions[5].activeSelf ) && enemy.isAlert)
        {
            allInstructions[4].SetActive(false); // Collect 2 Cards
            allInstructions[5].SetActive(false); // Collect 2 Cards Complete
            allInstructions[6].SetActive(true);  // Collect 2 cars failed
        }
        if(allInstructions[7].activeSelf && player._model.hasThrow)
        {
            allInstructions[7].SetActive(false);  // Use Skills
            allInstructions[8].SetActive(true);   // use skill complete
        }
    }

    System.Collections.IEnumerator PauseGameForSeconds(float duration)
    {
        Time.timeScale = 0f; // Pausar el tiempo

        float pauseEndTime = Time.realtimeSinceStartup + duration;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return null;
        }

        Time.timeScale = 1f; // Reanudar el tiempo
    }
}
