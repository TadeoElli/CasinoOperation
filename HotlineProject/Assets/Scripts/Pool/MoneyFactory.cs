using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyFactory : MonoBehaviour
{
    public static MoneyFactory Instance { get; private set; }

    [SerializeField] Money _moneyPrefab;
    [SerializeField] int _initialAmount;

    [SerializeField] private ObjectPool<Money> _moneyPool;

    void Awake()
    {
        if (Instance) Destroy(this);
        else Instance = this;

        _moneyPool = new ObjectPool<Money>(MoneyCreator, Money.TurnOn, Money.TurnOff, _initialAmount);

        /* LAMBDAS
        _bulletPool = new ObjectPool<Bullet>(() => Instantiate(_bulletPrefab, transform),
                                             (b) => b.gameObject.SetActive(true),
                                             (b) => b.gameObject.SetActive(false),
                                             _initialAmount);
        */
    }


    Money MoneyCreator()
    {
        return Instantiate(_moneyPrefab, transform);
    }

    public Money GetObject()
    {
        //Pedimos al pool un objeto
        return _moneyPool.GetObject();
    }

    public void ReturnObject(Money b)
    {
        //Llamamos al pool para devolverle la bala
        _moneyPool.ReturnObject(b);
    }
    
}
