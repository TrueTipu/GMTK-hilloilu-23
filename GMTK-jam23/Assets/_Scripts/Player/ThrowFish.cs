using UnityEngine;
using System.Collections;

public class ThrowFish : MonoBehaviour
{
    [SerializeField] Fishing fishing;
    [SerializeField] FishBait fishBaitPrefab;

    private void Update()
    {
        if (((PlayerState.Instance.GetState() != State.Fishing) || (PlayerState.Instance.GetState() != State.Hiding)) && fishing.FishCount > 0 && Input.GetKeyDown(KeyCode.E))
        {
            fishing.SetFishCount(fishing.FishCount - 1);
            Instantiate(fishBaitPrefab, transform.position, Quaternion.identity);
        }
    }
}
