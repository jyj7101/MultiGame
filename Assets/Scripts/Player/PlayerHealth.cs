using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float currentHp;
    private float healthPercent;
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
            Debug.Log("damage");
            if(other.GetComponent<Damaging>() != null)
                Damaged(other.GetComponent<Damaging>().damage);
        }
    }

    public void Damaged(float damage)
    {
        float cal = damage - data.defence;
        if (cal < 0)
        {
            return;
        }
        else if (currentHp > cal)
        {
            currentHp -= cal;
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
