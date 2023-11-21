using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] string GameID = "5479204";
    [SerializeField] string RewardedGameID = "Rewarded_Android";

    [SerializeField] private StaminaSistem staminaSistem;

    private int originalStamina;
    public bool isInMenu = true;

    void Start()
    {
        staminaSistem = FindObjectOfType<StaminaSistem>();
        Advertisement.AddListener(this);
        Advertisement.Initialize(GameID);
        isInMenu = true;
    }

    public void ShowAD()
    {
        if(!Advertisement.IsReady())
        {
            return;
        }
        if(isInMenu)
            originalStamina = staminaSistem.currentstamina;

        Advertisement.Show(RewardedGameID);
    }

    public void OnUnityAdsDidError(string message)
    {
        // cuando el anuncio tira un error se ejecuta este metodo
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // cuando el anuncio comienza
    }

    public void OnUnityAdsReady(string placementId)
    {
        // cuando el anuncio se precargo
        Debug.Log("el ad esta listo para mostrarse");
    }
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // cuando se termina de ver el anuncio se ejecuta este metodo
        if(placementId == RewardedGameID)
        {
            if(showResult == ShowResult.Finished)
            {
                Debug.Log("El usuario vio todo el ad");
                if (staminaSistem != null && isInMenu)
                {
                    staminaSistem.AdUpStamina();
                    staminaSistem.UpdateStamina();
                    staminaSistem.UpdateTimer();
                }
                else if(staminaSistem != null && !isInMenu)
                {
                    Time.timeScale = 1f;
                    Invoke("LoadRestartScene", 0.2f);
                }
            }
            else if (showResult == ShowResult.Skipped || showResult == ShowResult.Failed)
            {
                if (staminaSistem != null)
                {                                       
                    staminaSistem.currentstamina = originalStamina; // Restaurar la stamina a su valor original al inicio del anuncio
                    staminaSistem.UpdateStamina(); // Actualiza la interfaz de usuario si es necesario
                    Debug.Log("El usuario vio mitad de ad");
                }
            }
        }
    }
    private void LoadRestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
