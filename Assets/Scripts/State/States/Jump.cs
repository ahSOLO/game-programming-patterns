using UnityEngine;
using UnityEngine.AI;

public class Jump : IState
{
    private Rigidbody rb;
    private float _jumpSpeed;
    
    public Jump(Capsule_State capsule, float jumpSpeed)
    {
        _jumpSpeed = jumpSpeed;
        rb = capsule.GetComponent<Rigidbody>();
    }

    public void OnEnter()
    {
        Debug.Log("Entering Jump");
        rb.velocity = new Vector3(rb.velocity.x, _jumpSpeed, rb.velocity.z);
    }

    public void Tick()
    {
        Debug.Log("Jumping");
    }

    public void OnExit()
    {

    }
}