using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private Transform _player;
    public static float _sensivityX = 1, _sensivityY = 1;
    private float _xRot, _yRot;
    private Rigidbody _playerRb;
    [SerializeField] private AnimationCurve _curve, _curve2;


    void Start()
    {
        _playerRb = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    void Update()
    {
        _xRot = Input.GetAxis("Mouse Y");
        _yRot = Input.GetAxisRaw("Mouse X");

        Keyframe keyFrameX = new Keyframe(Time.time, transform.rotation.x, 0, 0, 0, 0);
        _curve.AddKey(keyFrameX);

        Keyframe keyFrameY = new Keyframe(Time.time, transform.rotation.y, 0, 0, 0, 0);
        _curve2.AddKey(keyFrameY);
        
        _playerRb.angularVelocity = new Vector3(_playerRb.angularVelocity.x, _yRot * _sensivityY, 0);
    }

    void LateUpdate()
    {          
        transform.Rotate(new Vector3(1, 0, 0) * -_xRot * _sensivityX);       
    }
}
