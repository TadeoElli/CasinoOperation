using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class StaminaPreview : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI staminatext;
    [SerializeField] TextMeshProUGUI timertext;

    [SerializeField] private StaminaSistem staminaSistem;
    // Start is called before the first frame update
    void Start()
    {
        //staminaSistem = FindObjectOfType<StaminaSistem>();
        StaminaSistem.Instance.staminatext = staminatext;
        StaminaSistem.Instance.timertext = timertext;
        
    }

    // Update is called once per frame
    void Update()
    {/*
        staminaSistem.UpdateTimer();
        staminaSistem.UpdateStamina();
        */
    }
}
