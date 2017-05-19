using UnityEngine;
using System.Collections;

public class Bee : MonoBehaviour {

    public int pollen = 0;

    float maxspeed = 10.0f;
    Vector3 velocity;
    float slowRad = 10.0f;
    float deceleration = 5.0f;
    Vector3 acceleration;
    Rigidbody rb;

    public Vector3 seekpos;

    public bool arriveEnabled = false;
    public bool seekEnabled = false;
    public bool feeding = false;
    public bool giving = false;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        //search state
        GetComponent<StateMachine>().SwitchState(new SearchState(this.gameObject));
    }

    // Update is called once per frame
    void Update() {

        Vector3 force = Calculate();
        Vector3 newAccel = force / rb.mass;
        acceleration = Vector3.Lerp(acceleration, newAccel, 0.1f);
        velocity += acceleration * Time.deltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxspeed);

        if (velocity.magnitude > float.Epsilon)
        {
            // transform.LookAt(velocity);
            transform.forward = velocity;
        }

        transform.position += velocity * Time.deltaTime;
    }

    Vector3 Calculate()
    {
        Vector3 force = Vector3.zero;

        if (arriveEnabled && seekpos != null)
            force += Arrive(seekpos);

        return force;
    }

    Vector3 Seek(Vector3 position)
    {
        Vector3 toTarget = position - transform.position;
        toTarget.Normalize();
        toTarget *= maxspeed;

        return toTarget - velocity;
    }

    Vector3 Arrive(Vector3 position)
    {
        Vector3 toTarget = position - transform.position;
        float distance = toTarget.magnitude;

        if(distance < 5)
        {
            return velocity * 0.5f;
        }

        float ramped = maxspeed * (distance / (slowRad * deceleration));
        float clamped = Mathf.Min(ramped, maxspeed);
        Vector3 desired = toTarget * (clamped / distance);

        return desired - velocity;
    }


}
