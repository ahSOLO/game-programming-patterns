using UnityEngine;
using UnityEngine.AI;

public class Move : IState
{
    private Rigidbody rb;
    private float _speed;
    private readonly InputReader _inputReader;
    
    public Move(Capsule_State capsule, InputReader inputReader, float speed)
    {
        _speed = speed;
        rb = capsule.GetComponent<Rigidbody>();
        _inputReader = inputReader;
    }

    public void OnEnter()
    {
        Debug.Log("Entering Move");
    }

    public void Tick()
    {
        rb.velocity = new Vector3(_inputReader.ReadInput().x, 0, _inputReader.ReadInput().y) * _speed;
        Debug.Log("Moving");
    }

    public void OnExit()
    {

    }
}