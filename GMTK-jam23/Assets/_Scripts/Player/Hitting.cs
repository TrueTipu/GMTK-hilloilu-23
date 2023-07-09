using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;


class Hitting : TimeAttack
{
    
    int hitShot = 0;

    Lonkero longerr;

    public override void DoStuff()
    {
        //Noms
        RightTiming();
    }

    public override void RightTiming()
    {
        if (hitShot >= 4)
        {
            //mutaattikala
            GameManager.Instance.ChangeToLastScene();
        }
        else
        {
            hitShot += 1;
        }
        return;
    }
}

