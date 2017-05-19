using UnityEngine;
using System.Collections;

public class DepositeState : State {

    GameObject parent;
    GameObject hive;

    public DepositeState(GameObject p, GameObject h)
    {
        parent = p;
        hive = h;
    }

    public override void Enter()
    {
    
    }

    public override void Reason() {
        if(parent.GetComponent<Bee>().pollen == 0)
        {
            parent.GetComponent<StateMachine>().SwitchState(new SearchState(parent));
        }
    }

    public override void Act()
    {
        //deposite
        hive.GetComponent<Hive>().polen += parent.GetComponent<Bee>().pollen;
        parent.GetComponent<Bee>().pollen = 0;
    }

    public override void Exit() {

    }
}
