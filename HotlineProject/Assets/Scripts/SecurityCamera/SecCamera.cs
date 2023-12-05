using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SecCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float rotationModifier, rotationSpeed;
    public Vector3[] destination;
    public bool isActive = true;
    private float timer, skillTimer;
    private int index;
    [SerializeField] private Animator animator;
    private Vector3 playerPos;

    [Header("FOV")]
    [SerializeField] public FieldOfView fieldOfView;
    [SerializeField] public float _minViewRadius;
    [SerializeField] public float _maxViewRadius;
    [SerializeField] private float _viewAngle;
    [SerializeField] private LayerMask objectLayer;
    void Start()
    {
        fieldOfView.SetValues(_minViewRadius, _viewAngle, objectLayer);     //Inicializo los valores del fov
        index = 0;
        timer = 0f;
        skillTimer = 40f;
        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive)
        {
            fieldOfView.SetAimDirection(-transform.up);     //Funcion para q apunte a donde queremos(tiene q ser update)
            fieldOfView.SetOrigin(transform.position);      //Funcion para q empieze desde donde estamos(tiene q ser update)
            if(timer > 20f)
            {
                if( index == destination.Length - 1)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
                timer = 0;
            }
            timer = timer + 1 * Time.deltaTime;
            Vector3 vectorToTarget = destination[index] - transform.position;
            vectorToTarget.z = 0f;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
        }
    }

    private void FixedUpdate() {
        if(isActive)
        {
            if (CheckEnemiesInRange())
            {
                if(skillTimer > 40f)
                {
                    animator.SetTrigger("Activate");
                    Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, _maxViewRadius);       //Agarra colliders dentro del radio

                        foreach (Collider2D hitCollider in colliderArray)   
                        {
                            if(hitCollider.TryGetComponent<Enemy>(out Enemy enemy)){   //Si ese collider pertenece a un objeto con la clase enemigo(se puede cambiar desp es un ej)
                                    enemy.SearchNPC(playerPos);
                                }
                        }
                    skillTimer = 0f;
                }
            }
            skillTimer = skillTimer + 1 * Time.deltaTime;
        }
    }

    public void DesactivateFeedback()
    {
        fieldOfView.ChangeDesactivatedMaterial();
    }

    public void ActivateFeedback()
    {
        fieldOfView.RestoreMaterial();
    }
    public bool CheckEnemiesInRange()      //chequea que haya un enemigo en rango para que ataque automaticamente a melee
    {
        Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, _minViewRadius);       //Agarra colliders dentro del radio

        if(colliderArray != null)
        {
            foreach (Collider2D hitCollider in colliderArray)   
            {
                if(hitCollider.TryGetComponent<Player>(out Player player)){   //Si ese collider pertenece a un objeto con la clase enemigo(se puede cambiar desp es un ej)
                    if(InFieldOfView(player.transform.position))
                    {
                        playerPos = player.transform.position;
                        return true;
                    }
                }
            }
            return false;
        }
        else
            return false;
    }

    private bool InFieldOfView(Vector3 targetPos)
    {
        Vector3 dir = targetPos - transform.position;
        //Que este dentro de la distancia maxima de vision
        if (dir.sqrMagnitude > _minViewRadius * _minViewRadius) return false;

        if (InLineOfSight(dir, _minViewRadius)) return false;
    
        //Que este dentro del angulo
        return Vector3.Angle(-transform.up, dir) <= _viewAngle/2;
    }
    public bool InLineOfSight(Vector3 direction, float radius)
    {
        //RaycastHit hit;
        return Physics2D.Raycast(transform.position, direction, radius, objectLayer);
        //return Physics.SphereCast(transform.position,1.5f, direction, out hit, direction.magnitude, objectLayer);
    }
}
