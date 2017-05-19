using UnityEngine;
using System.Collections;

public class ReturnState : State {

    GameObject parent;
    Vector3 hivePos;
    GameObject hive;

    public ReturnState(GameObject p)
    {
        parent = p;
    }

    public override void Enter()
    {
        Debug.Log("Entered Return State");
        hive = GameObject.Find("Hive");
        hivePos = hive.transform.position;
        parent.GetComponent<Bee>().seekpos = hivePos;
        parent.GetComponent<Bee>().arriveEnabled = true;
    }

    public override void Reason()
    {
        if (Vector3.Distance(parent.transform.position, hivePos) < hive.transform.localScale.x)
            parent.GetComponent<StateMachine>().SwitchState(new DepositeState(parent,hive));
    }
    public override void Act()
    {
       
    }
    public override void Exit()
    {
        parent.GetComponent<Bee>().arriveEnabled = false;
    }
}
