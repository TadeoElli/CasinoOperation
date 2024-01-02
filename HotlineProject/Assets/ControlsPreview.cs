using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ControlsPreview : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button joystickButton, tapButton;
    [SerializeField] private GameObject joystickImage, joystickImageOn, tapImage, tapImageOn;
    [SerializeField] private GameDataController gameDataController;
    void Start()
    {
        gameDataController = FindObjectOfType<GameDataController>();
        joystickButton.onClick.AddListener(gameDataController.SetJoystick);
        tapButton.onClick.AddListener(gameDataController.SetNavMesh);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameDataController.navMesh)
        {
            joystickImage.SetActive(true);
            joystickImageOn.SetActive(false);
            tapImage.SetActive(false);
            tapImageOn.SetActive(true);
        }
        else
        {
            joystickImage.SetActive(false);
            joystickImageOn.SetActive(true);
            tapImage.SetActive(true);
            tapImageOn.SetActive(false);
        }
    }
}
