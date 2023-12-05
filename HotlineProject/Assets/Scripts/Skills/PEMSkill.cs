using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PEMSkill : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private SecCamera secCamera;
    private Image skillCooldown;
    [SerializeField] private float cooldown;
    void Start()
    {
        //secCamera = GetComponentInParent<SecCamera>();
        skillCooldown = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(skillCooldown.fillAmount >= 1.0f)
        {
            secCamera.isActive = true;
            secCamera.ActivateFeedback();
        }
        skillCooldown.fillAmount += 1.0f/cooldown * Time.deltaTime;
    }

    private void OnMouseOver() {
        if(Input.GetMouseButtonDown(0))
        {
            if(skillCooldown.fillAmount >= 1.0f)
            {
                PEMAbility();
            }
        }
    }

    private void PEMAbility()
    {
        secCamera.DesactivateFeedback();
        secCamera.isActive = false;
        skillCooldown.fillAmount = 0; 

    }
}
