using UnityEngine;
using UnityEngine.AI;

public class Idle : IState
{
    private Rigidbody rb;
    private readonly float _slowRate;
    
    public Idle(Capsule_State capsule, float slowRate)
    {
        rb = capsule.GetComponent<Rigidbody>();
        _slowRate = slowRate;
    }

    public void OnEnter()
    {
        Debug.Log("Entering Idle");
    }

    public void Tick()
    {
        Debug.Log("Idling");
    }

    public void OnExit()
    {

    }
}