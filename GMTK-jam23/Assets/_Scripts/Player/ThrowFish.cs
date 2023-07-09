using UnityEngine;
using System.Collections;

public class ThrowFish : MonoBehaviour
{
    [SerializeField] Fishing fishing;
    [SerializeField] FishBait fishBaitPrefab;

    bool hasThrown;
    private void Update()
    {
        if(fishing.FishCount > 0)
        {
            if (hasThrown == false && GameManager.Instance.Phase == 0)
            {
                hasThrown = true;
                TextDisplay.Instance.Show("Heitto");
            }
        }
        if (((PlayerState.Instance.GetState() != State.Fishing) || (PlayerState.Instance.GetState() != State.Hiding)) && fishing.FishCount > 0 && Input.GetKeyDown(KeyCode.E))
        {
            fishing.SetFishCount(fishing.FishCount - 1);
            Instantiate(fishBaitPrefab, transform.position, Quaternion.identity);
            AudioManager.Instance.Play("Heitto");
            if (!GameManager.Instance.MonsterActive)
            {
                GameManager.Instance.MonsterActive = true;
                Invoke(nameof(ShowVaro), 5);
            }

        }
    }
    private void ShowVaro()
    {
        TextDisplay.Instance.Show("Varo");
    }
}
