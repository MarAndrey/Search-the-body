using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    public static float _moveSpeed, _rotationSpeed;
    [SerializeField, Header("Сила прыжка:")] private float _jumpForce;
    private bool isGrounded = true;
    private Rigidbody _rb;
    [SerializeField] private GameObject _DroneObj;
    [SerializeField] private Transform spawnPoint;
    private CapsuleCollider _col; 

    void Start()
    {
        _col = GetComponent<CapsuleCollider>();
        _rb = GetComponent<Rigidbody>();
        transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");      

        Jump();
        Boost();
        Limitation();
        SpawnDrone();
    }

    void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerMove()
    {   
        if (isGrounded)
        {
            Vector3 velocity = new Vector3(horizontalInput, 0, verticalInput) * _moveSpeed;
            velocity.y = _rb.velocity.y;
            Vector3 worldVelocity = transform.TransformVector(velocity);
            _rb.velocity = worldVelocity;
        }        

        //Player вращается в скрипте CameraFollowing:)
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //_rb.velocity += Vector3.up * _jumpForce;
            _rb.AddForce(Vector3.up * _jumpForce);
        }
    }

    void Boost()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _moveSpeed = 25f;
        }
        else 
        {
            _moveSpeed = 10f;
        }
    }

    void Limitation()
    {
        if (transform.position.y < -10)
        {
            transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
        }
    }

    bool isSpawningDrone = false;
    void SpawnDrone()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isSpawningDrone = !isSpawningDrone;

            if (isSpawningDrone)
            {
                Instantiate(_DroneObj, transform.position + new Vector3(1, 0, 0), transform.rotation);
                _col.enabled = false;
                _rb.isKinematic = true;
            }
            else
            {
                GameObject.FindWithTag("Drone").SendMessage("DestroyDrone", false);
                _col.enabled = true;
                _rb.isKinematic = false;
                
            }
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
