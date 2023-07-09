using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Phase", menuName = "ScriptableObjects/Phase")]
[System.Serializable]
public class Phase : ScriptableObject
{
    public int phase;

    private void OnEnable()
    {
        this.hideFlags = HideFlags.DontUnloadUnusedAsset;
        phase = 0;
    }
}

