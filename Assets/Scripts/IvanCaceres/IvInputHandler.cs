using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class IvInputHandler : MonoBehaviour
{
    [SerializeField] private GameObject PlayerController;

    private IvIAimable _characterAim;
    private IvIMoveable _characterMovement;
    private IvIAttackable _characterAttack;

    private void Awake()
    {
        _characterAim = PlayerController.GetComponent<IvIAimable>();
        _characterMovement = PlayerController.GetComponent<IvIMoveable>();
        _characterAttack = PlayerController.GetComponent<IvIAttackable>();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        //Debug.Log(context.ReadValue<Vector2>());

        _characterMovement.Move(context.ReadValue<Vector2>());
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        //Debug.Log(context.ReadValue<Vector2>());

        _characterAim.Position = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        //Debug.Log(context.phase);
        if(context.phase == InputActionPhase.Started)
            _characterAttack.Attack(_characterAim.Position);
    }
}
