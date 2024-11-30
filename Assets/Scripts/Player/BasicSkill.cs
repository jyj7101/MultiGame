using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSkill : MonoBehaviour
{
    private PlayerMove playerMove;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashAmount;
    [SerializeField] private float dashCoolTime;

    private IEnumerator co;
    private void Start()
    {
        playerMove = GetComponent<PlayerMove>();
    }

    private void FixedUpdate()
    {
        
    }

    private void Update()
    {
        
    }

    private IEnumerator Dash()
    {
        co = Dash();
        playerMove.canMove = false;
        float runTime = 0;
        while (runTime < dashTime) {
            transform.position += playerMove.Direction * curve.Evaluate(runTime / dashTime) * dashAmount;
            runTime += Time.deltaTime;
            yield return null;
        }
        playerMove.canMove = true;
        runTime = 0;
        while (runTime < dashCoolTime)
        {
            runTime += Time.deltaTime;
            yield return null;
        }

        co = null;
    }

    public void OnDashSkill()
    {
        if(co == null)
            StartCoroutine(Dash());


    }

    public void OnHealSkill()
    {

    }
}
