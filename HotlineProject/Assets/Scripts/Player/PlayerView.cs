using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{

    [SerializeField] private Player _player;
    [SerializeField] private SkinManager skinManager;
    [SerializeField] private SpriteRenderer bodyImage, headImage, leftArmImage, rightArmImage;
    private Animator animator;
    private void Awake() {
        animator = GetComponent<Animator>();
        skinManager = FindObjectOfType<SkinManager>();
    }

    private void Start() {
        bodyImage.sprite = skinManager.bodySprite[skinManager.index];
        headImage.sprite = skinManager.headSprite[skinManager.index];
        leftArmImage.sprite = skinManager.leftArmSprite[skinManager.index];
        rightArmImage.sprite = skinManager.rightArmSprite[skinManager.index];
    }

    // Update is called once per frame
    void Update()       // Para que el sprite este siempre sobre el player
    {
        this.transform.position = _player.transform.position;
    }

    public void Rotate(Vector3 target)      //Roto hacia la direccion donde se esta moviendo
    {
        float angleRad = Mathf.Atan2(target.y - this.transform.position.y, target.x - this.transform.position.x);
        float angleGrad = (180 / Mathf.PI) * angleRad + 90;
        this.transform.rotation = Quaternion.Euler(0,0, angleGrad);
    }

    public void PlayAnim()
    {
        animator.SetBool("IsMoving", true);
    }

    public void StopAnim()
    {
        animator.SetBool("IsMoving", false);
    }
}
