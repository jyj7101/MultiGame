using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Subject
{
    private UIController _uiController;
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
    [HideInInspector] public float MaxHp { get; private set; }
    [SerializeField] private PlayerHealthData data;

    private void Awake()
    {
        _uiController = FindObjectOfType<UIController>().GetComponent<UIController>();
        currentHp = data.maxHp;
        MaxHp = data.maxHp;
    }

    private void Start()
    {
        NotifyObservers();
    }

    private void OnEnable()
    {
        if (_uiController)
            Attach(_uiController);
    }

    private void OnDisable()
    {
        if (_uiController)
            Detach(_uiController);
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
            return;
        else if (currentHp >= damage)
            currentHp -= damage;
        
        NotifyObservers();

        if (currentHp <= 0)
            PlayerDie();
        
    }

    public void Heal(float healAmount)
    {
        CurrentHp += healAmount;
        NotifyObservers();
    }

    public bool PlayerDie()
    {
        return true;
    }
}
