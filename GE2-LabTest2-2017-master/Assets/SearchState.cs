using UnityEngine;
using System.Collections;
using System;

public class SearchState : State {

    float searchDist = 20;
    GameObject parent;
    GameObject flower;
    Vector3 arrivePos;
    bool searching = true;

    public SearchState(GameObject p)
    {
        parent = p;
    }

    public override void Enter()
    {
        Debug.Log("Entered Search State");
        //set seekposition
        GameObject spawner = GameObject.Find("resourceSpawner");
        arrivePos = spawner.transform.position + (UnityEngine.Random.insideUnitSphere * UnityEngine.Random.Range(5, 50));
        arrivePos.y = parent.transform.position.y;

        parent.GetComponent<Bee>().arriveEnabled = true;
        parent.GetComponent<Bee>().seekpos = arrivePos;

        //reset variables
        searching = true;
    }

    public override void Reason()
    {
        
        if (!searching)
        {
            if (Vector3.Distance(parent.transform.position, arrivePos) < 5)
            {
                parent.GetComponent<StateMachine>().SwitchState(new FeedState(parent, flower));
            }
        }
       
    }
    public override void Act()
    {
       
        if (searching)
        {
            //get new seekpoint
            if (Vector3.Distance(parent.transform.position, arrivePos) < 5)
            {
                GameObject spawner = GameObject.Find("resourceSpawner");
                arrivePos = spawner.transform.position + (UnityEngine.Random.insideUnitSphere * UnityEngine.Random.Range(5, 50));
                arrivePos.y = parent.transform.position.y;

                parent.GetComponent<Bee>().seekpos = arrivePos;
            }
        }
        //check if near flower;
        Collider[] cols = Physics.OverlapSphere(parent.transform.position, searchDist);

        foreach (Collider col in cols)
        {
            if (col.transform.tag.ToLower().Contains("flower"))
            {
                arrivePos = col.gameObject.transform.position;
                searching = false;
                flower = col.gameObject;
                parent.GetComponent<Bee>().seekpos = arrivePos;
            }
        }

        //if anther bee eats this bees flower
        if (searching == false && flower == null)
        {
            searching = true;
        }
    }
    public override void Exit()
    {
        parent.GetComponent<Bee>().arriveEnabled = false;
    }

}
