using System.Collections.Generic;
using System.Linq;
using UnityEngine;


class Monster : Singleton<Monster>
{
    int dir = 1;
    [SerializeField] float speed;
    [SerializeField] float directionChangeChance;

    [SerializeField] float maxAgressivity;
    [SerializeField] float minDist;

    [Header("Agressivity variables")]
    [SerializeField] float agressivitySpeed;
    [SerializeField] float fishingMultiplier;
    [SerializeField] float movingCloseMultiplier;
    [SerializeField] float movingFarMultiplier;
    [SerializeField] float hidingMultiplier;
    [SerializeField] float defaultIgnoranceMultiplier;
    [SerializeField] float catchDegrease = 4;
    float agressivity;
    float dangerLevel;

    bool eating;

    PlayerState player;

    private void Start()
    {
        player = PlayerState.Instance;
    }


    private void Update()
    {
        Move();
        CalculateAgressivity();
        var _dL = CalculateDanger(transform.position);
        dangerLevel = _dL != -1 ? _dL : dangerLevel;

        if(dangerLevel >= maxAgressivity *0.95f && player.GetState() != State.Hiding)
        {
            //cool animation här
            Debug.Log("kuolit");
        }
    }

    public void CatchFish(Vector2 _fishPos)
    {
        var _val = Random.value;
        if(CalculateDanger(_fishPos) * 0.1f >= _val)
        {
            Debug.Log(CalculateDanger(_fishPos) * 0.1f);
            Debug.Log(_val);
            
            agressivity = Mathf.Clamp(agressivity - catchDegrease, 0.001f, maxAgressivity);
            //nappausanim
        }
    }

    private float CalculateDanger(Vector2 _position)
    {
        float _dis = Mathf.Abs(_position.x - transform.position.x);
        if (_dis > minDist) return -1;

        _dis = Mathf.Clamp(_dis * 2, 1f, minDist * 2);

        //Debug.Log(_dis);
        //Debug.Log(a);
        return (1 / Mathf.Sqrt(_dis)) * agressivity;
    }

    void CalculateAgressivity()
    {
        float _distance = Mathf.Abs(player.transform.position.x - transform.position.x);

        if (eating) return;

        switch (player.GetState())
        {
            case State.Fishing:
                if(_distance < minDist)
                {
                    agressivity += agressivitySpeed * fishingMultiplier * Time.deltaTime;
                }
                break;
            case State.Moving:
                if (_distance < minDist)
                {
                    agressivity += agressivitySpeed * movingCloseMultiplier * Time.deltaTime;
                }
                else if (_distance > minDist)
                {
                    agressivity += agressivitySpeed * movingFarMultiplier * Time.deltaTime;
                }
                break;
            case State.Hiding:
                if (_distance < minDist)
                {
                    agressivity -= agressivitySpeed * hidingMultiplier * Time.deltaTime;
                }
                else if (_distance > minDist)
                {
                    agressivity -= agressivitySpeed * defaultIgnoranceMultiplier * Time.deltaTime;
                }
                break;
            case State.Idling:
                if (_distance > minDist)
                { 
                    agressivity -= agressivitySpeed * defaultIgnoranceMultiplier * Time.deltaTime;
                }
                break;
            default:
                break;
        }
        agressivity = Mathf.Clamp(agressivity, 0.001f, maxAgressivity);
    }

    void Move()
    {
        float _fps = 1 / Time.deltaTime;
        int _randValue = Mathf.RoundToInt(UnityEngine.Random.Range(1, (1 / directionChangeChance) * _fps));
        if (_randValue == 1)
        {
            dir *= -1;
        }

        if (transform.position.x < Borders.leftX)
        {
            dir = 1;
        }
        if (transform.position.x > Borders.rightX)
        {
            dir = -1;
        }

        if(player.GetState() == State.Fishing)
        {
            dir = (transform.position.x - player.transform.position.x) < 0 ? 1 : -1;
        }

        transform.position += new Vector3(dir * speed * Time.deltaTime, 0);
    }
}

