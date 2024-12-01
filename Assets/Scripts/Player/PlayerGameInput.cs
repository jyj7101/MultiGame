using Photon.Pun.Demo.Asteroids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerGameInput : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private BasicSkill skill;
    private PlayerMove playerMove;
    private PlayerAttack playerAttack;

    public IEnumerator co;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        skill = GetComponent<BasicSkill>();
        playerMove = GetComponent<PlayerMove>();
        playerAttack = GetComponent<PlayerAttack>();
    }


    public void OnMoveInput(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();
        playerMove.SetDirection(new Vector3(input.x, 0f, input.y));
    }

    public void OnDashSkill(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            skill.StartDash();     
        }
    }

    public void OnHealSkill(InputAction.CallbackContext context)
    {
        if(context.performed) 
            playerHealth.Heal(3);
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
            playerAttack.Shoot();
    }
}
