using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float maxSpeed;
    [SerializeField] float acceleration;
    [SerializeField] float deceleration;
    public float Velocity { get; private set; }
    public float Dir { get; private set; }

    [SerializeField] Transform cameraAnchor;

    [SerializeField] Fishing fishing;

    [SerializeField] Transform leftMax;
    [SerializeField] Transform rightMax;

    bool facingRight = true;

    private void Start()
    {
        Helpers.Camera.GetComponent<CameraMovement>().Init(cameraAnchor);
    }

    void FixedUpdate()
    {
        Move();
    }
    void Flip(float _dir)
    {
        if(_dir < 0 && facingRight || _dir > 0 && !facingRight)
        {
            //transform.localScale *= new Vector2(-1, 1);
            facingRight = !facingRight;
        }

    }

    void Move()
    {
        if (fishing.IsFishing) return;

        Dir = Input.GetAxisRaw("Horizontal");
        Flip(Dir);

        if(transform.position.x < leftMax.position.x && Dir < 0)
        {
            Velocity = 0;
            return;
        }
        if (transform.position.x > rightMax.position.x && Dir > 0)
        {
            Velocity = 0;
            return;
        }

        float _maxSpeedChange = 0;
        if (Dir != 0)
        {
            if (Mathf.Sign(Dir) != Mathf.Sign(Velocity) && Velocity != 0)
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

        float _targetSpeed = Dir * maxSpeed * Time.deltaTime;

        Velocity = Mathf.MoveTowards(Velocity, _targetSpeed, _maxSpeedChange);

        transform.position += new Vector3(Velocity, 0, 0);
        cameraAnchor.position = transform.position + new Vector3(10*Velocity, 0,0);
    }
}