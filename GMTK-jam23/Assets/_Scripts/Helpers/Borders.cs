using UnityEngine;
using System.Collections;


public class Borders : Singleton<Borders>
{
    [SerializeField] Transform left;
    [SerializeField] Transform right;
    public static float leftX => Instance.left.position.x;
    public static float rightX => Instance.right.position.x;
}
