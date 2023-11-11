using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkinPreview : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image bodyImage, headImage, leftArmImage, rightArmImage, lockImage;
    [SerializeField] private SkinManager skinManager;

    private void Awake() {
        skinManager = FindObjectOfType<SkinManager>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bodyImage.sprite = skinManager.bodySprite[skinManager.index];
        headImage.sprite = skinManager.headSprite[skinManager.index];
        leftArmImage.sprite = skinManager.leftArmSprite[skinManager.index];
        rightArmImage.sprite = skinManager.rightArmSprite[skinManager.index];

        if(!skinManager.unlocked[skinManager.index])
        {
            lockImage.enabled = true;
        }
        else
        {
            lockImage.enabled = false;
        }
    }
}
