using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
    public GameObject obj;

    float minX, minY, minZ, maxX, maxY, maxZ;

    private void Start()
    {
        AABB();
    }

    private void FixedUpdate()
    {
        CheckXYZ();
    }

    private void AABB()
    {
        minX = obj.transform.position.x - (obj.transform.localScale.x / 2);
        maxX = obj.transform.position.x + (obj.transform.localScale.x / 2);

        minY = obj.transform.position.y - (obj.transform.localScale.y / 2);
        maxY = obj.transform.position.y + (obj.transform.localScale.y / 2);

        minZ = obj.transform.position.z - (obj.transform.localScale.z / 2);
        maxZ = obj.transform.position.z + (obj.transform.localScale.z / 2);
    }

    private void CheckXYZ()
    {
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
            Debug.Log("Crush");
    }
}
