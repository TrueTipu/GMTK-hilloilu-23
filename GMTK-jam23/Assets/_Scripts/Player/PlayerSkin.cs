using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    [SerializeField] Sprite[] sevenUps;

    [SerializeField] SpriteRenderer sevenUpRenderer;

    [SerializeField] GameObject pamahdus;

    int cthulhuness = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)){
            sevenUpRenderer.sprite = sevenUps[cthulhuness];
            Instantiate (pamahdus, transform.position, Quaternion.identity);
            cthulhuness++;
        }
    }
}
