using UnityEngine;
using System.Collections;

public class Hide : MonoBehaviour
{
    public bool IsHiding{ get; private set; }
    [SerializeField] Fishing fishing;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !fishing.IsDoingStuff)
        {
            IsHiding = true;
            PlayerState.Instance.SetState(State.Hiding);
        }
        if (IsHiding && Input.GetKeyUp(KeyCode.LeftShift))
        {
            IsHiding = false;
        }
    }
}
