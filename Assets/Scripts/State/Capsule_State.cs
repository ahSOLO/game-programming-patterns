using System;
using UnityEngine;
using UnityEngine.AI;

public class Capsule_State : MonoBehaviour
{
    private StateMachine _stateMachine;
    private InputReader inputReader;
    private bool isGrounded;
    private bool isRunningAway;
    private Rigidbody rb;
    public GameObject runAwayDestination;

    [SerializeField] private float slowRate = 0.9f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpSpeed = 4f;

    private void Awake()
    {
        var navMeshAgent = GetComponent<NavMeshAgent>();
        
        _stateMachine = new StateMachine();

        inputReader = GetComponent<InputReader>();
        rb = GetComponent<Rigidbody>();

        var idle = new Idle(this, slowRate);
        var move = new Move(this, inputReader, speed);
        var jump = new Jump(this, jumpSpeed);
        var fall = new Fall();
        var runAway = new RunAway(this, runAwayDestination);

        At(idle, move, () => HasMoveInput());
        At(move, idle, () => !HasMoveInput());
        At(idle, jump, () => HasJumpInput() && isGrounded);
        At(move, jump, () => HasJumpInput() && isGrounded);
        At(jump, fall, () => isFalling());
        At(fall, idle, () => isGrounded);
        At(runAway, idle, () => !isRunningAway);

        _stateMachine.AddAnyTransition(runAway, () => isRunningAway);

        _stateMachine.SetState(fall);

        void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);
    }

    private void Update() => _stateMachine.Tick();

    public bool HasMoveInput()
    {
        return inputReader.ReadInput() != Vector3.zero;
    }

    public bool HasJumpInput()
    {
        return inputReader.ReadSpace();
    }

    public bool isFalling()
    {
        return rb.velocity.y < 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
            isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground")
            isGrounded = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RunCube")
            isRunningAway = true;

        else if (other.tag == "DestinationCube")
            isRunningAway = false;
    }
}