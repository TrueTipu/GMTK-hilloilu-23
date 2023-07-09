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
    [SerializeField] float cameraMultiplier = 5;

    [SerializeField] Transform cameraAnchor;

    [SerializeField] TimeAttack fishing;
    [SerializeField] Hide hiding;

    bool facingRight = true;

    private void OnEnable()
    {
        Helpers.Camera.GetComponent<CameraMovement>().Init(cameraAnchor);
    }
    private void Start()
    {
        StartCoroutine(Narise());
        AudioManager.Instance.PlayOnLoop("MerenAanet");
    }

    IEnumerator Narise()
    {
        while (true)
        {
            if (hiding != null)
            {
                if (hiding.IsHiding)
                {
                    yield return null;
                    continue;
                }
            }
            if (fishing.IsDoingStuff) 
            {
                yield return null;
                continue;
            }
            
            AudioManager.Instance.PlayRandom(new string[]{ "Narina", "Narina2", "Narina3"});



            yield return new WaitForSeconds(Random.Range(5, 15));
        }
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
        if(hiding != null)
        {
            if (hiding.IsHiding) return;
        }
        if (fishing.IsDoingStuff) return;

        Dir = Input.GetAxisRaw("Horizontal");
        Flip(Dir);

        if(Dir != 0)
        {
            PlayerState.Instance.SetState(State.Moving);
        }
        else
        {
            PlayerState.Instance.SetState(State.Idling);
        }

        if(transform.position.x < Borders.leftX && Dir < 0)
        {
            Velocity = 0;
            return;
        }
        if (transform.position.x > Borders.rightX && Dir > 0)
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
        cameraAnchor.position = transform.position + new Vector3(cameraMultiplier * Velocity, 0,0);
    }
}
