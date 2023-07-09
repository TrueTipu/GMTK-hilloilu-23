using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.PostProcessing;


public class Hide : MonoBehaviour
{
    [SerializeField] PostProcessProfile noHide;
    [SerializeField] PostProcessProfile hide;

    [SerializeField] SpriteRenderer light;
    [SerializeField] Lamp lampScript;
    [SerializeField] Color colorOff;

    public bool IsHiding{ get; private set; }
    [SerializeField] Fishing fishing;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !fishing.IsDoingStuff && PlayerState.Instance.GetState() != State.Dying)
        {
            GameManager.Instance.PPObjectReference.profile = hide;
            IsHiding = true;
            AudioManager.Instance.Play("LamppuOn");
            light.color = colorOff;
            lampScript.enabled = false;
            PlayerState.Instance.SetState(State.Hiding);
        }
        if (IsHiding && Input.GetKeyUp(KeyCode.LeftShift))
        {
            GameManager.Instance.PPObjectReference.profile = noHide;
            IsHiding = false;
            AudioManager.Instance.Play("LamppuOff");
            lampScript.enabled = true;
            light.color = Color.white;
        }
    }
}
