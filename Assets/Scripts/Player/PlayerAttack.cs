using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;

    public void Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}