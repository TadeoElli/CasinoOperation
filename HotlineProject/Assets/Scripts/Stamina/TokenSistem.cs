using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TokenSistem : MonoBehaviour
{
    public Text tokenText1, tokenText2; // Texto para mostrar las vidas en la interfaz
    
    [SerializeField] private GameDataController datacontroller;
    


    private void Start() {
        datacontroller = FindObjectOfType<GameDataController>();
        
    }
    public void Update()
    {
        tokenText1.text = " " + datacontroller.newScoreTokens.ToString();
        tokenText2.text = " " + datacontroller.newScoreTokens.ToString();
    }



}
