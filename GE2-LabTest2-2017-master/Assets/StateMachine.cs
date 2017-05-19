using UnityEngine;
using System.Collections;

public class StateMachine : MonoBehaviour {

    State currentState;
    public string state = "";

	void Update () {
        currentState.Reason();
        currentState.Act();
	}

    public void SwitchState(State newState)
    {
        if(newState != null)
        {
            if(currentState != null)
                currentState.Exit();
            currentState = newState;
            newState.Enter();

            state = currentState.ToString();
        }
        
    }
}
