using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class CameraMovement : MonoBehaviour
{

    Transform cameraAnchor;

    public void Init(Transform _cam)
    {
        cameraAnchor = _cam;
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(cameraAnchor.position.x, transform.position.y, transform.position.z); 
    }
}

