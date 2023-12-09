using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    Vector3 _moveDir, _initialPos;
    [SerializeField] private GameObject baseImage;
    [SerializeField] float maxMagnitude = 100;
    GameDataController _dataController;

    void Start()
    {
        _initialPos = transform.position;
        _dataController = FindObjectOfType<GameDataController>();
        if(_dataController.navMesh)
        {
            this.gameObject.SetActive(false);
            baseImage.SetActive(false);
        }
    }
    

    public Vector3 GetMovementInput()
    {
        Vector3 modifiedMoveDir = new Vector3(_moveDir.x, _moveDir.y, 0);
        return modifiedMoveDir / maxMagnitude;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _moveDir = Vector3.ClampMagnitude((Vector3)eventData.position - _initialPos, maxMagnitude);
        transform.position = _initialPos + _moveDir;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = _initialPos;
        _moveDir = Vector3.zero;
    }
}
