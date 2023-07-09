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
        cthulhuness = GameManager.Instance.Phase - 1;
        if (cthulhuness != -1)
        {
            ChangeSkin(0);
        }

    }
    public void ChangeSkin(int plus)
    {
        cthulhuness += plus;
        sevenUpRenderer.sprite = sevenUps[cthulhuness];
        Instantiate(pamahdus, transform.position, Quaternion.identity);
        if(cthulhuness == sevenUps.Length - 1)
        {
            StartCoroutine(GameManager.Instance.NextScene());
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}
