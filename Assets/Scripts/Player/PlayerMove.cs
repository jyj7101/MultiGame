using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private static PlayerMove instance;
    public static PlayerMove Instance
    {
        get
        {
            if (null == instance)
                return null;
            return instance;
        }
    }


    [SerializeField] private PlayerMoveData data;
    private Vector3 Direction;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        LookAt();
        transform.position += Direction * data.moveSpeed;
    }

    private void LookAt()
    {
        if (Direction != Vector3.zero)
        {
            var currentAngle = transform.rotation;
            var targetAngle = Quaternion.LookRotation(Direction);

            transform.rotation = Quaternion.Lerp(currentAngle, targetAngle, Time.deltaTime * data.rorationSpeed);
        }
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();
        Direction = new Vector3(input.x, 0f, input.y);
    }
}
