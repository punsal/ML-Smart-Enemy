using UnityEngine;
using MLAgents;

public class TrainedEnemyAgent : Agent
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public Transform Target;
    public override void AgentReset()
    {
        if(transform.position.y < 0)
        {
            EnemyScore = 0;
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
            transform.localPosition = new Vector3(0f, 0.5f, 0f);
        }

        float posX = Random.value * 8 - 4;
        float posZ = Random.value * 8 - 4;
        Target.localPosition = new Vector3(posX, 0.5f, posZ);
    }

    public override void CollectObservations()
    {
        AddVectorObs(Target.localPosition);
        AddVectorObs(transform.localPosition);

        AddVectorObs(rb.velocity.x);
        AddVectorObs(rb.velocity.z);
    }

    public float speed = 10f;
    public override void AgentAction(float[] vectorAction, string textAction)
    {
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = vectorAction[0];
        controlSignal.z = vectorAction[1];
        rb.AddForce(controlSignal * speed);

        float distanceToTarget = Vector3.Distance(transform.localPosition, Target.localPosition);

        if(transform.position.y < 0)
        {
            Done();
        }
    }
    
    [HideInInspector]
    public int EnemyScore = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            EnemyScore++;
            SetReward(1.0f);
            Done();
        }
    }
    
    public void ResetAgent()
    {
        EnemyScore = 0;
        Done();
    }
}
