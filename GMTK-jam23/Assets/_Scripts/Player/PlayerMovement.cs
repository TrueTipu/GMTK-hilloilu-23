using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float maxSpeed;
    [SerializeField] float acceleration;
    [SerializeField] float deceleration;
    float velocity;

    public float MaxSpeed => maxSpeed * Time.deltaTime;

    private void Start()
    {
        Helpers.Camera.GetComponent<CameraMovement>().Init(this);
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float _dir = Input.GetAxisRaw("Horizontal");

        float _maxSpeedChange = 0;
        if (_dir != 0)
        {
            if (Mathf.Sign(_dir) != Mathf.Sign(velocity) && velocity != 0)
            {
                _maxSpeedChange = deceleration * Time.deltaTime;
            }
            else
            {
                _maxSpeedChange = acceleration * Time.deltaTime;
            }
        }
        else
        {
            _maxSpeedChange = deceleration * Time.deltaTime;
        }

        float _targetSpeed = _dir * maxSpeed * Time.deltaTime;

        velocity = Mathf.MoveTowards(velocity, _targetSpeed, _maxSpeedChange);

        transform.position += new Vector3(velocity, 0, 0);
    }
}
