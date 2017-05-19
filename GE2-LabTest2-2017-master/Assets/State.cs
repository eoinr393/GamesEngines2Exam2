using UnityEngine;
using System.Collections;

public abstract class State  {

    public abstract void Enter();
    public abstract void Reason();
    public abstract void Act();
    public abstract void Exit();

}
