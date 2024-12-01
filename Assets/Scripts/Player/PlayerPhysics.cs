using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    public float gravity = .1f;
    private bool isGravity;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (ShootRay())
        {
            isGravity = false;
        }
        else
            isGravity = true;

        if(isGravity)
        {
            transform.position += Vector3.down * gravity;
        }
    }

    private bool ShootRay()
    {
        bool result = false;

        Vector3 offset = new Vector3(0.5f, 0, -0.5f);
        Vector3 offset1 = new Vector3(0.5f, 0, 0.5f);

        Vector3 rayPos0 = transform.position + offset;
        Vector3 rayPos1 = transform.position - offset;
        Vector3 rayPos2 = transform.position + offset1;
        Vector3 rayPos3 = transform.position - offset1;

        if (Physics.Raycast(rayPos0, Vector3.down, .6f) || Physics.Raycast(rayPos1, Vector3.down, .6f) || Physics.Raycast(rayPos2, Vector3.down, .6f) || Physics.Raycast(rayPos3, Vector3.down, .6f))
        {
            result = true; 
        }

        return result;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            isGravity = false; 
        }
    }
}