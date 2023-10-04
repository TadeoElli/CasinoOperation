using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaLevel : MonoBehaviour
{
    public int vidas = 0; // Cantidad inicial de vidas
    public int maxVidas = 3; // Cantidad máxima de vidas permitidas
    public Text vidasText; // Texto para mostrar las vidas en la interfaz

    private void Start()
    {
        ActualizarUI();
    }

    void ActualizarUI()
    {
        vidasText.text = " " + vidas.ToString();
    }
    public void RestarVida()
    {
        if (vidas > 0)
        {
            vidas--;
            ActualizarUI();
        }
    }
    public void RecargarVida()
    {
        if (vidas < maxVidas)
        {
            vidas++;
            ActualizarUI();
        }
    }
}
