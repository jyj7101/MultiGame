using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float damping;
    private PlayerMove playerMove;

    void Start()
    {
        playerMove = PlayerMove.Instance;    
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, playerMove.transform.position + offset + (MousePos.Instance.transform.position / 5), damping * Time.deltaTime);
        //transform.position = Vector3.Lerp(transform.position, playerMove.transform.position + offset + (MousePos.Instance.transform.position / 5), 1);
    }
}
