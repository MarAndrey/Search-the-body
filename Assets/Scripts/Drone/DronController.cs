using UnityEngine;

public class DronController : MonoBehaviour
{
    private Rigidbody _rb;
    private float horizontalInput, verticalInput, upInput, yRot;
    [SerializeField] private float _lerpMoveSpeed, _upInputLerp, _lerpRotationY;
    [SerializeField] private float _droneSpeed, _rotationSpeed;
    [SerializeField] private float _maxMoveSpeed;
    [SerializeField] private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        yRot = Mathf.MoveTowards(yRot, Input.GetAxisRaw("Mouse X"), Time.deltaTime * _lerpRotationY);

        HorizontalInput();
        VerticalInput();
        UpInput();
    }

    void FixedUpdate()
    {
        DroneMove();
    }

    void DroneMove()
    {

        Vector3 velocity = new Vector3(horizontalInput * _droneSpeed, upInput * 50, verticalInput * _droneSpeed);
        Vector3 worldVelocity = transform.TransformVector(velocity);
        _rb.velocity = worldVelocity;

        _rb.angularVelocity = new Vector3(_rb.angularVelocity.x, yRot * _rotationSpeed, _rb.angularVelocity.z);
    }

    float UpInput()
    {
        float min = -1f, max = 1f;

        if (Input.GetKey(KeyCode.Space))
        {
            upInput = Mathf.MoveTowards(upInput, max, _upInputLerp * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            upInput = Mathf.MoveTowards(upInput, min, _upInputLerp * Time.deltaTime);
        }
        else if (!Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.LeftShift))
        {
            upInput = Mathf.MoveTowards(upInput, 0f, _upInputLerp * Time.deltaTime);
        }

        return upInput;
    }

    float VerticalInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = Mathf.MoveTowards(verticalInput, 1, _lerpMoveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            verticalInput = Mathf.MoveTowards(verticalInput, -1, _lerpMoveSpeed * Time.deltaTime);
        }
        else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            verticalInput = Mathf.MoveTowards(verticalInput, 0, _lerpMoveSpeed * Time.deltaTime);
        }

        return verticalInput;
    }

    float HorizontalInput()
    {
        if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = Mathf.MoveTowards(horizontalInput, 1, _lerpMoveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = Mathf.MoveTowards(horizontalInput, -1, _lerpMoveSpeed * Time.deltaTime);
        }
        else if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            horizontalInput = Mathf.MoveTowards(horizontalInput, 0, _lerpMoveSpeed * Time.deltaTime);
        }

        return horizontalInput;
    }

     void DestroyDrone(bool isActive)
     {
        if (isActive == false)
        {
            Destroy(gameObject);
        }
     }
}
