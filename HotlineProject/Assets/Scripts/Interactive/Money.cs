using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    // Start is called before the first frame update
    float _currentLifeTime;
    [SerializeField] float _lifeTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _currentLifeTime -= Time.deltaTime;

        if (_currentLifeTime <= 0)
        {
            MoneyFactory.Instance.ReturnObject(this);
        }
    }
    private void Reset()
    { 
        _currentLifeTime = _lifeTime;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "NPC")
        {
            MoneyFactory.Instance.ReturnObject(this);
        }
    }
    public static void TurnOn(Money m)
    {
        m.Reset();
        m.gameObject.SetActive(true);
    }

    public static void TurnOff(Money m)
    {
        m.gameObject.SetActive(false);
    }
}
