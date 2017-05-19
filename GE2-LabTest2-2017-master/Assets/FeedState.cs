using UnityEngine;
using System.Collections;

public class FeedState : State {

    GameObject parent;
    GameObject flower;
 
    float time = 0;

    public FeedState(GameObject p, GameObject f)
    {
        parent = p;
        flower = f;
    }

    // Use this for initialization
    public override void Enter()
    {
        Debug.Log("Entered Feed State");
        parent.GetComponent<Bee>().arriveEnabled = false;
        time = 0;
    }

    public override void Reason()
    {
        if (flower.GetComponent<Flower>().polen < 1)
        {
            parent.GetComponent<StateMachine>().SwitchState(new ReturnState(parent));
        }
    }
    public override void Act()
    {
        if(time >= 60)
        {
            flower.GetComponent<Flower>().polen -= 1;
            parent.GetComponent<Bee>().pollen += 1;
            time = 0;
        }
        time++;
    }

    public override void Exit()
    {

    }
}
