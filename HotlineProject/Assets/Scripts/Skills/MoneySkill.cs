using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoneySkill : MonoBehaviour
{
    // Start is called before the first frame update
    private Player player;
    PlayerModel _model;
    private Image skillCooldown;
    [SerializeField] private bool hasToActivate = false;
    [SerializeField] private float cooldown;
    private void Awake() {
        player = FindObjectOfType<Player>();
        skillCooldown = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hasToActivate && Vector3.Distance(this.transform.position, player.transform.position) < player.moneyRadius && skillCooldown.fillAmount >= 1.0f)
        {
            MoneyAbility();
            hasToActivate = false;
        }
        skillCooldown.fillAmount += 1.0f/cooldown * Time.deltaTime;
        

    }

    private void OnMouseOver() {
        if(Input.GetMouseButtonDown(0))
        {
            if(skillCooldown.fillAmount >= 1.0f)
            {
                if(Vector3.Distance(this.transform.position, player.transform.position) < player.moneyRadius)
                {
                    MoneyAbility();
                }
                else
                {
                    hasToActivate = true;
                }
            }
        }
    }

    private void MoneyAbility()
    {
        player._model.ThrowMoney();
        var newMoney = MoneyFactory.Instance.GetObject();

        //Seteamos la posicion
        newMoney.transform.position = player.transform.position;
        skillCooldown.fillAmount = 0; 
    }
}