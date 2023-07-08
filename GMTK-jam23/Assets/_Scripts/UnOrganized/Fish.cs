﻿using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class Fish : MonoBehaviour, Catchable
{

    FishData fishData;

    Action<Fish> killFish;


    public void Init(float _size, float _catchMoment, float _catchTime, float _lifeTime, Action<Fish> _killFish)
    {
        transform.localScale *= _size;
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
            collision.GetComponent<Fishing>().SetCanFish(true, this);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Fishing>().SetCanFish(false, null);
        }
    }
}
