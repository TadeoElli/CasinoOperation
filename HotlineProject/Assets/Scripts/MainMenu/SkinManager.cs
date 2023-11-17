using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public static SkinManager instance;
    [SerializeField] public Sprite[] bodySprite, headSprite, leftArmSprite, rightArmSprite;

    public int index, maxIndex;

    [SerializeField] private GameDataController datacontroller;

    private Vector2 touchStartPos;
    private bool isSwiping = false;
    private float swipeThreshold = 50f;

    private void Awake()
    {
        if (instance != null)
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

    void Update()
    {
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
                                LeftSwitch();
                            }
                            else
                            {
                                RigthSwitch();
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

    public void BuySkin()
    {
        if (datacontroller.newScoreTokens >= 2)
        {
            datacontroller.newScoreTokens = datacontroller.newScoreTokens - 2;
            datacontroller.newUnlockedSkins[index] = true;
            datacontroller.SaveData();
        }
    }

    public void RigthSwitch()
    {
        if (index == maxIndex)
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
        if (index == 0)
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
        if (!datacontroller.newUnlockedSkins[index])
        {
            index = 0;
        }
    }
}
