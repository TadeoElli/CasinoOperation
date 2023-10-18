using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class StaminaLevel : MonoBehaviour
{
    public int vidas; // Cantidad inicial de vidas
    public int maxVidas = 3; // Cantidad m�xima de vidas permitidas
    public Text vidasText; // Texto para mostrar las vidas en la interfaz
    



    public void ActualizarUI()
    {
        vidasText.text = " " + vidas.ToString();
    }
    public void RestarVida()
    {
        if (vidas > 0)
        {
            vidas--;
            GameManager.Instance.SaveData(vidas);
            ActualizarUI();
        }
    }
    public void RecargarVida()
    {
        if (vidas < maxVidas)
        {
            vidas++;
            GameManager.Instance.SaveData(vidas);
            ActualizarUI();
        }
    }
}
