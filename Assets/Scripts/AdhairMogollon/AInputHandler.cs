using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class AInputHandler : MonoBehaviour
{
    [SerializeField] private GameObject PlayerController;

    private AIAimable _characterAim;
    private AIMoveable _characterMovement;
    private AIAttackable _characterAttack;

    private void Awake()
    {
        _characterAim = PlayerController.GetComponent<AIAimable>();
        _characterMovement = PlayerController.GetComponent<AIMoveable>();
        _characterAttack = PlayerController.GetComponent<AIAttackable>();
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
        if (context.started)
        {
            _characterAttack.Attack(_characterAim.Position);
        }
    }
}
