using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkinPreview : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image bodyImage, headImage, leftArmImage, rightArmImage, lockImage;
    [SerializeField] private GameObject price;
    [SerializeField] private Button buyButton, selectButton;
    [SerializeField] private SkinManager skinManager;
    [SerializeField] private GameDataController datacontroller;

    private Vector2 touchStartPos;
    private bool isSwiping = false;
    private float swipeThreshold = 50f;

    private void Awake() {
        skinManager = FindObjectOfType<SkinManager>();
    }
    void Start()
    {
        datacontroller = FindObjectOfType<GameDataController>();
        buyButton.onClick.AddListener(skinManager.BuySkin);
        selectButton.onClick.AddListener(skinManager.SelectSkins);
    }

    // Update is called once per frame
    void Update()
    {
        bodyImage.sprite = skinManager.bodySprite[skinManager.index];
        headImage.sprite = skinManager.headSprite[skinManager.index];
        leftArmImage.sprite = skinManager.leftArmSprite[skinManager.index];
        rightArmImage.sprite = skinManager.rightArmSprite[skinManager.index];

        if(!datacontroller.newUnlockedSkins[skinManager.index])
        {
            lockImage.enabled = true;
            price.SetActive(true);
        }
        else
        {
            lockImage.enabled = false;
            price.SetActive(false);
        }

        HandleSwipeInput();
    }


    void HandleSwipeInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    isSwiping = true;
                    break;

                case TouchPhase.Moved:
                    if (isSwiping)
                    {
                        float swipeDelta = touch.position.x - touchStartPos.x;

                        if (Mathf.Abs(swipeDelta) > swipeThreshold)
                        {
                            if (swipeDelta > 0)
                            {
                                skinManager.LeftSwitch();
                            }
                            else
                            {
                                skinManager.RigthSwitch();
                            }

                            isSwiping = false;
                        }
                    }
                    break;

                case TouchPhase.Ended:
                    isSwiping = false;
                    break;
            }
        }
    }
}
