using UnityEngine;
using UnityEngine.AI;

public class RunAway : IState
{
    private Rigidbody rb;
    private readonly NavMeshAgent agent;
    private readonly GameObject _destination;
    
    public RunAway(Capsule_State capsule, GameObject destination)
    {
        agent = capsule.GetComponent<NavMeshAgent>();
        _destination = destination;
    }

    public void OnEnter()
    {
        Debug.Log("Entering Run Away");
        agent.enabled = true;
        agent.destination = _destination.transform.position;
    }

    public void Tick()
    {
        Debug.Log("Running Away");
    }

    public void OnExit()
    {
        agent.enabled = false;
    }
}