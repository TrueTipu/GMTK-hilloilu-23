using UnityEngine;
using System.Collections;

public class FishBait : MonoBehaviour
{
    Rigidbody2D rb2;
    [SerializeField] float fishThrowStrength;
    // Use this for initialization
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        float _cornerRad = Random.Range(2f, 2.7f);

        rb2.AddForce(new Vector2(Mathf.Cos(_cornerRad) * fishThrowStrength, Mathf.Sin(_cornerRad) * fishThrowStrength));


    }
    private void Update()
    {
        if(transform.position.y < Borders.FloorY)
        {
            Monster.Instance.CatchFishDone(transform.position);
            Destroy(gameObject);
        } 
    }
}
