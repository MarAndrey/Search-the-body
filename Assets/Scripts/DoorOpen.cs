using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private Transform _player;
    private bool isOpening;
    [SerializeField] private float _openSpeed;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (((transform.position.x - _player.position.x) <= 10) || ((transform.position.z - _player.position.z) <= 10))
        {
            if (Input.GetKeyDown(KeyCode.E) && isOpening)
            {
                transform.Translate(new Vector3(0, 0, 35) * Time.deltaTime * _openSpeed);
            }
            else if (Input.GetKeyDown(KeyCode.E) && isOpening == false)
            {
                transform.Translate(new Vector3(0, 0, 31.5f) * Time.deltaTime * _openSpeed);
            }
        }
    }
}
