using UnityEngine;
using System.Collections;
using System;

public class GameManager : Singleton<GameManager>
{

    public int Phase { get; private set; }
    // Use this for initialization

    public void ChangePhase()
    {
        Phase += 1;
    }

    public void ChangeToLastScene()
    {
        
    }
}
