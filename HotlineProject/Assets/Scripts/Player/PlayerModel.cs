using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel        //Esta clase va a manejar el gameObject jugador (moverlo, destruirlo si muere etc)
{

    //public event Action<float> OnStartMoving = delegate { };      Para usar desp

    //References
    private float timer;
    public bool hasThrow = false;
    public Player _player;
    UnityEngine.AI.NavMeshAgent agent;


    public PlayerModel(Player _user)        
    {
        _player = _user;
        agent = _player.agent;
    }
    private void Update() {
        if(timer > 2)
        {
            hasThrow = false;
        }
        else
        {
            timer = timer + 1 * Time.deltaTime;
        }
        
    }

    public void Movement(Vector3 target)      //Llamo al NavMeshAgent del jugador para indicarle la posicion hacia donde se tiene q mover
    {
        agent.SetDestination(new Vector3(target.x, target.y, _player.transform.position.z));
        _player.transform.forward = new Vector3(target.x - _player.transform.position.x, target.y - _player.transform.position.y, _player.transform.position.z);
    }

    public void ThrowMoney()
    {
        Collider2D[] colliderArray = Physics2D.OverlapCircleAll(_player.transform.position, _player.moneyRadius);       //Agarra colliders dentro del radio

        foreach (Collider2D hitCollider in colliderArray)   
        {
            if(hitCollider.TryGetComponent<NPC>(out NPC npc)){   //Si ese collider pertenece a un objeto con la clase enemigo(se puede cambiar desp es un ej)
                    npc.SearchMoney(_player.transform.position);
                }
        }
        hasThrow = true;
        timer = 0;
    }
}
