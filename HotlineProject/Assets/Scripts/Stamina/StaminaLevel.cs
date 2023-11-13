using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class StaminaLevel : MonoBehaviour
{
    public int vidas; // Cantidad inicial de vidas
    public int maxVidas = 3; // Cantidad m�xima de vidas permitidas
    public Text vidasText, tokenText1, tokenText2; // Texto para mostrar las vidas en la interfaz
    
    [SerializeField] private GameDataController datacontroller;


    private void Start() {
        datacontroller = FindObjectOfType<GameDataController>();
    }
    public void Update()
    {
        vidasText.text = " " + vidas.ToString();
        tokenText1.text = " " + datacontroller.newScoreTokens.ToString();
        tokenText2.text = " " + datacontroller.newScoreTokens.ToString();
    }
    public void RestarVida()
    {
        if (vidas > 0)
        {
            vidas--;
            datacontroller.newEnergy = vidas;
            datacontroller.SaveData();
            //ActualizarUI();
        }
    }
    public void RecargarVida()
    {
        if (vidas < maxVidas)
        {
            vidas++;
            datacontroller.newEnergy = vidas;
            datacontroller.SaveData();
            //ActualizarUI();
        }
    }
    public void RestablecerVida()
    {
        datacontroller.newEnergy = 0;
        datacontroller.newLevelsCompleted = 0;
        for (int i = 0; i < 12; i++)
        {
            datacontroller.newTokens[i] = true;
        }
        datacontroller.newScoreTokens = 0;
        datacontroller.SaveData();
        //ActualizarUI();
    }
}
