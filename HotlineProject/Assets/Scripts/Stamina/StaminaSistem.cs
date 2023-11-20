using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using static NotificationsManager;

public class StaminaSistem : MonoBehaviour
{

    [SerializeField] int maxStamina = 3;
    [SerializeField] float timeToRecharge = 10;
    public int currentstamina;

    DateTime nexStaminatime;
    DateTime LastSaminatime;

    bool recharging;

    [SerializeField] TextMeshProUGUI staminatext = null;
    [SerializeField] TextMeshProUGUI timertext = null;

    TimeSpan timer;
    [SerializeField] string titleNoti = "full stamina";
    [SerializeField] string textNoti = "Tenes la stamina a full";
    [SerializeField] IconSelect IconNoti = IconSelect.icon_reminder;


    [SerializeField] private SkinManager skinManager;
    [SerializeField] private GameDataController datacontroller;
    int id;

    private static StaminaSistem instance;

    public static StaminaSistem Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        skinManager = FindObjectOfType<SkinManager>();
        datacontroller = FindObjectOfType<GameDataController>();
        LoadData();
        StartCoroutine(RechargeStamina());

        if(currentstamina < maxStamina)
        {
            timer = nexStaminatime - DateTime.Now;
            id = NotificationsManager.Instance.DisplayNotification(titleNoti, textNoti, IconNoti, AddDuration(DateTime.Now, ((maxStamina - currentstamina + 1) * timeToRecharge) + 1 + (float)timer.TotalMinutes));
        }
    }

     public IEnumerator RechargeStamina()
    {
        UpdateTimer();
        UpdateStamina();
        recharging = true;

        while(currentstamina < maxStamina)
        {
            //checks de tiempo
            DateTime current = DateTime.Now;
            DateTime nextTime = nexStaminatime;

            bool addingStamina = false;

            while(current > nextTime)
            {

                if(currentstamina >= maxStamina)
                {
                    break;
                }

                currentstamina += 1;
                addingStamina = true;
                UpdateStamina();

                // predecir la proxima vez que se va a recargar stamina
                DateTime timetoadd = nextTime;

                //chequear si el susuario cerro la app
                if(LastSaminatime > nextTime)
                {
                    timetoadd = LastSaminatime;
                }

                nextTime = AddDuration(timetoadd, timeToRecharge);
            }

            // Si se recargo estamina
            if(addingStamina)
            {
                nexStaminatime = nextTime;
                LastSaminatime = DateTime.Now;
            }

            UpdateStamina();
            UpdateTimer();
            SaveData();

            yield return new WaitForEndOfFrame();
        }

        NotificationsManager.Instance.CancelNotification(id);
        recharging = false;
    }

    public void UpdateTimer()
    {
        if(currentstamina >= maxStamina)
        {
            timertext.text = "full stamina";
            return;
        }

        // estructura que da un intervalo de tiempo

        TimeSpan timer = nexStaminatime - DateTime.Now;

        timertext.text = timer.Minutes.ToString("00") + ":" + timer.Seconds.ToString("00");
    }

    public void UpdateStamina()
    {
        staminatext.text = currentstamina + "/" + maxStamina;
    }

    private DateTime AddDuration(DateTime timetoadd, float timeToRecharge)
    {
        return timetoadd.AddMinutes(timeToRecharge);
    }

    public void UseStamina(int staminaToUse)
    {
        if(currentstamina - staminaToUse >= 0)
        {
            // jugar nivel
            currentstamina -= staminaToUse;
            UpdateStamina();
            datacontroller.newEnergy = currentstamina;

            NotificationsManager.Instance.CancelNotification(id);
            id = NotificationsManager.Instance.DisplayNotification(titleNoti, textNoti, IconNoti, AddDuration(DateTime.Now, ((maxStamina - currentstamina + 1) * timeToRecharge) + 1 + (float)timer.TotalSeconds));

            if (!recharging)
            {
                // setear nextstaminatime y comenzar recarga
                nexStaminatime = AddDuration(DateTime.Now, timeToRecharge);
                StartCoroutine(RechargeStamina());
            }
            else
            {
                Debug.Log("No tenes stamina suficiente");
            }
        }
    }

    void SaveData()
    {
        datacontroller.newEnergy = currentstamina;
        PlayerPrefs.SetInt(PlayerPrefsKey._currentstaminakey, currentstamina);
        PlayerPrefs.SetString(PlayerPrefsKey._nextstaminatimekey, nexStaminatime.ToString());
        PlayerPrefs.SetString(PlayerPrefsKey._laststaminatimekey, LastSaminatime.ToString());


    }

    void LoadData()
    {
        currentstamina = PlayerPrefs.GetInt(PlayerPrefsKey._currentstaminakey, maxStamina);


        nexStaminatime = StringToDateTime(PlayerPrefs.GetString(PlayerPrefsKey._nextstaminatimekey));
        LastSaminatime = StringToDateTime(PlayerPrefs.GetString(PlayerPrefsKey._laststaminatimekey));
    }

    DateTime StringToDateTime(string date)
    {
        if(string.IsNullOrEmpty(date))
        {
            return DateTime.Now;
        }
        else
        {
            return DateTime.Parse(date);
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            SaveData();
        }
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    public void RestartStats()
    {
        datacontroller.newEnergy = 0;
        datacontroller.newLevelsCompleted = 0;
        for (int i = 0; i < 12; i++)
        {
            datacontroller.newTokens[i] = true;
        }
        for (int i = 0; i < 14; i++)
        {
            if(i==0)
            {
                datacontroller.newUnlockedSkins[i] = true;
            }
            else
            {
                datacontroller.newUnlockedSkins[i] = false;
            }
        }
        skinManager.index = 0;
        datacontroller.newScoreTokens = 0;
        datacontroller.SaveData();
        //ActualizarUI();
    }

    public void AdUpStamina()
    {
        if(currentstamina <= maxStamina)
        {
        currentstamina += 1;    
        }
    }
}
