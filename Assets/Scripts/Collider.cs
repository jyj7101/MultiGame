using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
    private Collider[] colliders;
    [HideInInspector] public bool isCollide;

    private void Start()
    {
        colliders = FindObjectsOfType<Collider>();
    }

    private void FixedUpdate()
    {
        foreach (var collider in colliders)
        {
            if(collider.enabled && collider != this) 
                AABB(collider.gameObject.transform);
        }
    }

    private bool AABB(Transform obj)
    {
        float minX = obj.transform.position.x - (obj.transform.localScale.x / 2);
        float maxX = obj.transform.position.x + (obj.transform.localScale.x / 2);

        float minY = obj.transform.position.y - (obj.transform.localScale.y / 2);
        float maxY = obj.transform.position.y + (obj.transform.localScale.y / 2);

        float minZ = obj.transform.position.z - (obj.transform.localScale.z / 2);
        float maxZ = obj.transform.position.z + (obj.transform.localScale.z / 2);
        
        float px = transform.position.x;
        float py = transform.position.y;
        float pz = transform.position.z;

        float sx = transform.localScale.x;
        float sy = transform.localScale.y;
        float sz = transform.localScale.z;

        float Mx = px + (sx / 2);
        float My = py + (sy / 2);
        float Mz = pz + (sz / 2);

        float mx = px - (sx / 2);
        float my = py - (sy / 2);
        float mz = pz - (sz / 2);

        if (Mx >= minX && mx <= maxX &&
            My >= minY && my <= maxY &&
            Mz >= minZ && mz <= maxZ)
            isCollide = true;
        else
            isCollide = false;

        return isCollide;
    }

    public bool GetCollide()
    {
        return isCollide;
    }
}
