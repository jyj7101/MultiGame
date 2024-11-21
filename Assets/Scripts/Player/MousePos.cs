using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePos : MonoBehaviour
{
    private Ray ray; 
    private Vector3 worldPos;
    private void Update()
    {
        ScreenToWorld(); 
        transform.position = worldPos;
    }

    private void ScreenToWorld()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 1000))
            worldPos = Utils.MakeYZero(hit.point);
    }
}
