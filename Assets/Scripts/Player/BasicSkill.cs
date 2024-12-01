using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSkill : Subject
{
    private PlayerMove playerMove;
    private PlayerHealth playerHealth;
    private UIController _uiController;

    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashAmount;
    [SerializeField] private float dashCoolTime;
    public float DashTimer { get; private set; }

    [SerializeField] private float healCoolTime;
    [SerializeField] private float healAmount;
    public float HealTimer { get; private set; }

    private void Awake()
    {
        _uiController = FindObjectOfType<UIController>().GetComponent<UIController>();
        playerMove = GetComponent<PlayerMove>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Start()
    {
        DashTimer = HealTimer = 1;
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

    private IEnumerator dco;
    private IEnumerator Dash()
    {
        dco = Dash();
        playerMove.canMove = false;
        float runTime = 0;
        while (runTime < dashTime) {
            transform.position += curve.Evaluate(runTime / dashTime) * dashAmount * playerMove.Direction;
            runTime += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        playerMove.canMove = true;
        runTime = 0;
        while (runTime < dashCoolTime)
        {
            runTime += Time.deltaTime;
            DashTimer = runTime / dashCoolTime;
            NotifyObservers();
            yield return new WaitForFixedUpdate();
        }
        DashTimer = 1;
        NotifyObservers();
        dco = null;
    }

    private IEnumerator hco;
    private IEnumerator Heal()
    {
        hco = Heal();
        float runTime = 0;
        playerHealth.Heal(healAmount);
        while (runTime < healCoolTime)
        {
            runTime += Time.deltaTime;
            HealTimer = runTime / healCoolTime;
            NotifyObservers();
            yield return new WaitForFixedUpdate();
        }
        HealTimer = 1;
        NotifyObservers();
        hco = null;
    }

    public void StartDash()
    {
        if (dco == null)
            StartCoroutine(Dash());
    }

    public void StartHeal()
    {
        if (hco == null)
            StartCoroutine(Heal());
    }
}
