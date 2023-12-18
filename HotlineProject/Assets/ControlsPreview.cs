using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ControlsPreview : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button joystickButton, tapButton;
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
        
    }
}
