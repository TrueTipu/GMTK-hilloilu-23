using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using System.Collections;

class Monster : Singleton<Monster>
{
    int dir = 1;

    [SerializeField] SpoopyPants audioTick;

    [SerializeField] float speed;
    [SerializeField] float directionChangeChance;

    [SerializeField] float maxAgressivity;
    [SerializeField] float minDist;
    [SerializeField] float minDist2;

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

    bool showText = false;

    bool eating;

    [SerializeField] Transform graphic;
    [SerializeField] Animator animator;

    PlayerState player;

    private void Start()
    {
        player = PlayerState.Instance;
        StartCoroutine(Splash());
        StartCoroutine(Sound());
    }

    IEnumerator Sound()
    {
        while (true)
        {
            if (eating || (maxAgressivity / dangerLevel) > 2 || dangerLevel < 1)
            {
                yield return null;
                continue;
            }
            Debug.Log("Here");
            audioTick.Play();
            if(!showText && GameManager.Instance.Phase == 0)
            {
                showText = true;
                TextDisplay.Instance.Show("Lyhty");
            }

            yield return new WaitForSeconds(Mathf.Clamp((maxAgressivity / dangerLevel) / 2, 0, 5));
        }
    }
     IEnumerator Splash()
    {
        while (true)
        {
            if (Random.value > 0.95f && !eating)
            {
                Debug.Log("Hei");
                animator.SetBool("Splash", true);
                graphic.position = new Vector3(this.transform.position.x, player.transform.position.y);
                Invoke(nameof(StopAnim), 0.1f);
            }
            yield return new WaitForSeconds(0.5f);
        }

    }
    private void Update()
    {
        Move();

        if (!GameManager.Instance.MonsterActive) return;

        CalculateAgressivity();
        var _dL = CalculateDanger(player.transform.position);
        dangerLevel = _dL != -1 ? _dL : dangerLevel;


        if(dangerLevel >= maxAgressivity *1.8f && player.GetState() != State.Hiding)
        {
            //cool animation här
            Debug.Log("kuolit");
            GameManager.Instance.LoadCurrentScene();
        }
    }


    public void CatchFish(Vector2 _fishPos)
    {
        var _val = Random.value;
        if(CalculateDanger(_fishPos) * 0.1f >= _val)
        {
            Debug.Log(CalculateDanger(_fishPos) * 0.1f);
            Debug.Log(_val);

            CatchFishDone(_fishPos);
        }
    }
    public void CatchFishDone(Vector2 _fishPos)
    {
        Debug.Log("KALA");
        agressivity = Mathf.Clamp(agressivity - catchDegrease, 0.001f, maxAgressivity);

        Vector2 _offset = new Vector2(0, 30);
        graphic.position = _fishPos - _offset;

        animator.SetBool("IsJumping", true);

        eating = true;
        Invoke(nameof(StopEating), 3.09f);
    }

    void StopEating()
    {
        eating = false;
        animator.SetBool("IsJumping", false);


    }
    void StopAnim()
    {
        animator.SetBool("Splash", false);
    }
    private float CalculateDanger(Vector2 _position)
    {
        float _dis = Mathf.Abs(_position.x - transform.position.x);
        if (_dis > minDist) return 0;

        if(_dis < minDist2)
        {
            return 2 * agressivity;
        }
        else { return agressivity; }
       
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

