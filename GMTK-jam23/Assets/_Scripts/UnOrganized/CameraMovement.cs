using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class CameraMovement : MonoBehaviour
{
    [SerializeField] float smooth;

    Transform playerPos;

    public void Init(PlayerMovement _player)
    {
        playerPos = _player.GetComponent<Transform>();
    }

    void Update()
    {
        Vector2 position = Vector2.Lerp(transform.position, playerPos.position, smooth);
        transform.position = new Vector3(position.x, transform.position.y, transform.position.z);
    }
}

