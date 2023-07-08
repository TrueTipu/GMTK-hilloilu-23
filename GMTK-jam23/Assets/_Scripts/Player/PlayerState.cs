using UnityEngine;
using System.Collections;

public class PlayerState : Singleton<PlayerState>
{
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
