using UnityEngine;
using System.Collections;

public class PlayerState : Singleton<PlayerState>
{
    public float FishCount { get; set; }

    State state;
    public State GetState() => state;
    public void SetState(State _state)
    {
        state = _state;
    }

}

public enum State
{
    Fishing,
    Moving,
    Hiding,
    Idling,
}
