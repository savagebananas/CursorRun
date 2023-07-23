using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Helps activate/cycle the behaviors of a game object

public class StateMachineManager : MonoBehaviour
{
    public State CurrentState;

    private void Start()
    {
        if (CurrentState != null)
        {
            CurrentState.OnStart();
        }
    }

    private void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.OnUpdate();
        }
    }

    private void LateUpdate()
    {
        if (CurrentState != null)
        {
            CurrentState.OnLateUpdate();
        }
    }

    public void setNewState(State state)
    {
        if (state != null)
        {
            CurrentState = state;
            CurrentState.OnStart();
        }
    }
}
