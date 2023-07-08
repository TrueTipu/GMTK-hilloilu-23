using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScript : MonoBehaviour
{
    int spaceCount;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceCount += 1;
        }
        if(spaceCount > 15)
        {
            GameManager.Instance.EndScene();
        }
    }
}
