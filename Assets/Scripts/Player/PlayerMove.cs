using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoSingleton<PlayerMove>
{
    [SerializeField] private PlayerMoveData data;
    private Vector3 direction;
    public bool canMove; // need hide

    public Vector3 Direction { get; private set;  }

    public void SetDirection(Vector3 dir) => Direction = dir;

    private void Start() => canMove = true;


    private void Update()
    {
        direction = Direction;
    }

    private void FixedUpdate()
    {
        Move();
        transform.LookAt(MousePos.Instance.transform.position);
    }

    private void Move()
    {
        if (!canMove)
            return;
        transform.position += direction * data.moveSpeed;
    }
}