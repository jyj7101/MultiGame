using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : Observer
{
    private PlayerHealth playerHealth;
    private float _currentHp;
    
    private BasicSkill skill;
    private float _healCool;
    private float _dashCool;

    [SerializeField] private Image hpFill;
    [SerializeField] private Image healCoolTimeImg;
    [SerializeField] private Image DashCoolTimeImg;
    private TextMeshProUGUI hpText;

    private void Start()
    {
        hpText = hpFill.gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    public override void Notify(Subject subject)
    {
        if (!playerHealth)
            playerHealth = subject.GetComponent<PlayerHealth>();

        if(playerHealth)
            _currentHp = playerHealth.CurrentHp;

        if(!skill) 
            skill = subject.GetComponent<BasicSkill>();

        if (skill)
        {
            _healCool = skill.HealTimer;
            _dashCool = skill.DashTimer;
        }

    }

    private void Update()
    {
        HpUpdate();
        HealUpdate();
        DashUpdate();
    }

    private void HpUpdate()
    {
        float healthPercent = _currentHp / playerHealth.MaxHp;
        hpFill.fillAmount = healthPercent;
        hpText.text = _currentHp.ToString();
    }

    private void HealUpdate()
    {
        healCoolTimeImg.fillAmount = _healCool;
    }

    private void DashUpdate()
    { 
        DashCoolTimeImg.fillAmount = _dashCool;
    }
}
