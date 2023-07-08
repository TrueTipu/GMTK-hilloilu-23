using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class Lonkero : MonoBehaviour, Catchable
{

    FishData fishData;

    Action<Lonkero> killFish;

    public void Init(float _catchMoment, float _catchTime, float _lifeTime, Action<Lonkero> _killFish)
    {
        fishData = new FishData(_catchTime, _catchMoment);
        killFish = _killFish;
        Invoke(nameof(InvokeKillFish), _lifeTime);
    }
    void InvokeKillFish() { killFish(this); }

    public FishData GetData()
    {
        CancelInvoke();
        killFish(this);
        return fishData;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Hei");
            collision.GetComponent<Hitting>().SetCanFish(true, this);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Hitting>().SetCanFish(false, null);
        }
    }
}
