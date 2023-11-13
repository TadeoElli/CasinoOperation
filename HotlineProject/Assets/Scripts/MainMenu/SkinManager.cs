using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkinManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static SkinManager instance;
    [SerializeField] public Sprite[] bodySprite, headSprite, leftArmSprite, rightArmSprite;
    
    public int index, maxIndex;

    [SerializeField] private GameDataController datacontroller;
    
    private void Awake() {

        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        
    }
    void Start()
    {
        index = 0;
        maxIndex = bodySprite.Length - 1;

        datacontroller = FindObjectOfType<GameDataController>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BuySkin()
    {
        if(datacontroller.newScoreTokens >= 2)
        {
            datacontroller.newScoreTokens = datacontroller.newScoreTokens - 2;
            datacontroller.newUnlockedSkins[index] = true;
            datacontroller.SaveData();
        }
        
    }
    public void RigthSwitch()
    {
        if(index == maxIndex)
        {
            index = 0;
        }
        else
        {
            index++;
        }
    }

    public void LeftSwitch()
    {
        if(index == 0)
        {
            index = maxIndex;
        }
        else
        {
            index--;
        }
    }

    public void SelectSkins()
    {
        if(!datacontroller.newUnlockedSkins[index])
        {
            index = 0;
        }
    }
}
