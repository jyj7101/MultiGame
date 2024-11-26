using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
            Instantiate(bullet, transform.position, Quaternion.identity);
    }
}