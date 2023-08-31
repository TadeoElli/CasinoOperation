using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel        //Esta clase va a manejar el gameObject jugador (moverlo, destruirlo si muere etc)
{

    //public event Action<float> OnStartMoving = delegate { };      Para usar desp

    //References

    public Player _player;
    UnityEngine.AI.NavMeshAgent agent;


    public PlayerModel(Player _user)        
    {
        _player = _user;
        agent = _player.agent;
    }

    public void Movement(Vector3 target)      //Llamo al NavMeshAgent del jugador para indicarle la posicion hacia donde se tiene q mover
    {
        agent.SetDestination(new Vector3(target.x, target.y, _player.transform.position.z));
        _player.transform.forward = new Vector3(target.x - _player.transform.position.x, target.y - _player.transform.position.y, _player.transform.position.z);
    }

}
