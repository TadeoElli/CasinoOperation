using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkinManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static SkinManager instance;
    [SerializeField] public Sprite[] bodySprite, headSprite, leftArmSprite, rightArmSprite;
    [SerializeField] public bool[] unlocked;
    
    public int index, maxIndex;

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

        for (int i = 0; i < unlocked.Length; i++)
        {
            if(i==0)
            {
                unlocked[i] = true;
            }
            else
            {
                unlocked[i] = false;
            }
        }
    }
    void Start()
    {
        index = 0;
        maxIndex = bodySprite.Length - 1;

        

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BuySkin()
    {
        unlocked[index] = true;
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
}
