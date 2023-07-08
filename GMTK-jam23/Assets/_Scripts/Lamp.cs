using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    [SerializeField] GameObject light;
    [SerializeField] float timerAmount;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0){
            Instantiate (light, transform.position, Quaternion.identity);
            timer = timerAmount;
        }
    }
}
