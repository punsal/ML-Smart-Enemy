using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class EnemyAgent : Agent
{
    public Vector3 resetPosition;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    public Transform Target;
    public override void AgentReset()
    {
        if (transform.position.y < 0)
        {
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
            transform.position = resetPosition;
        }

        float posX = Random.value * 8 - 4;
        float posZ = Random.value * 8 - 4;
        Target.position = new Vector3(posX, 0.5f, posZ);
    }

    public override void CollectObservations()
    {
        AddVectorObs(Target.position);
        AddVectorObs(transform.position);

        AddVectorObs(rb.velocity.x);
        AddVectorObs(rb.velocity.z);
    }

    public float speed = 10;
    public override void AgentAction(float[] vectorAction, string textAction)
    {
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = vectorAction[0];
        controlSignal.z = vectorAction[1];
        rb.AddForce(controlSignal * speed);

        float distanceToTarget = Vector3.Distance(transform.position, Target.position);

        if(distanceToTarget < 1.42f)
        {
            SetReward(1.0f);
            Done();
        }

        if(transform.position.y < 0)
        {
            Done();
        }
    }

}
