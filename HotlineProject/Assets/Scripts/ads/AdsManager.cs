using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] string GameID = "5479204";
    [SerializeField] string RewardedGameID = "Rewarded_Android";

    private int originalStamina;

    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(GameID);
    }

    public void ShowAD()
    {
        if(!Advertisement.IsReady())
        {
            return;
        }

        originalStamina = StaminaSistem.Instance.currentstamina;

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
                if (StaminaSistem.Instance != null)
                {
                    StaminaSistem.Instance.AdUpStamina();
                    StaminaSistem.Instance.UpdateStamina();
                    StaminaSistem.Instance.UpdateTimer();
                }
            }
            else if (showResult == ShowResult.Skipped || showResult == ShowResult.Failed)
            {
                if (StaminaSistem.Instance != null)
                {                                       
                    StaminaSistem.Instance.currentstamina = originalStamina; // Restaurar la stamina a su valor original al inicio del anuncio
                    StaminaSistem.Instance.UpdateStamina(); // Actualiza la interfaz de usuario si es necesario
                    Debug.Log("El usuario vio mitad de ad");
                }
            }
        }
    }
}
