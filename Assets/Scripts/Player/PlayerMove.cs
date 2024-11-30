using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoSingleton<PlayerMove>
{
    [SerializeField] private PlayerMoveData data;
    private Vector3 direction;
    public bool canMove; // need hide

    public Vector3 Direction { get; private set;  }

    private void Update()
    {
        Direction = direction;
        canMove = true;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (!canMove)
            return;
        LookAt();
        transform.position += direction * data.moveSpeed;
    }

    private void LookAt()
    {
        //if (Direction != Vector3.zero)
        //{
        //    var currentAngle = transform.rotation;
        //    var targetAngle = Quaternion.LookRotation(Direction);

        //    transform.rotation = Quaternion.Lerp(currentAngle, targetAngle, Time.deltaTime * data.rorationSpeed);
        //}
        transform.LookAt(MousePos.Instance.transform.position);

    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();
        direction = new Vector3(input.x, 0f, input.y);
    }
}
