using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float healthPercent;
    private float currentHp;
    public float CurrentHp 
    {
        get { return currentHp; } 
        set 
        {
            if (value + currentHp >= data.maxHp)
                currentHp = data.maxHp;
            else
                currentHp += value;
        } 
    }
    [SerializeField] private Image hpFill;
    [SerializeField] private PlayerHealthData data;

    private void Start()
    {
        currentHp = data.maxHp;
    }

    private void Update()
    {
        healthPercent = currentHp / data.maxHp;
        hpFill.fillAmount = healthPercent;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Attack"))
        {
            if(other.GetComponent<Damaging>() != null)
                Damaged(other.GetComponent<Damaging>().damage);
        }
    }

    public void Damaged(float trueDamage)
    {
        float damage = trueDamage - data.defence;
        if (damage < 0)
        {
            return;
        }
        else if (currentHp >= damage)
        {
            currentHp -= damage;
        }
        else
        {
            PlayerDie();
        }
    }


    public bool PlayerDie()
    {
        return true;
    }
}
