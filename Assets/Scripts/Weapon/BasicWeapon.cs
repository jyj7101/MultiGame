using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : MonoBehaviour
{
    public float Damage;
    private Vector3 dir;
    [SerializeField] private BasicWeaponData data;


    void Start()
    {
        dir = MousePos.Instance.transform.position - transform.position;
        dir = Vector3.Normalize(dir);
    }

    void FixedUpdate()
    {
        transform.position += dir * data.bulletSpeed;
        StartCoroutine(DelayedDestroy());
    }
    protected IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(data.destroyTime);
        Destroy(gameObject);
    }
}
