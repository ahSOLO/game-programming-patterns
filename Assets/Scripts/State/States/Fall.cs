using UnityEngine;
using UnityEngine.AI;

public class Fall : IState
{
    
    public Fall()
    {

    }

    public void OnEnter()
    {
        Debug.Log("Entering Fall");
    }

    public void Tick()
    {
        Debug.Log("Falling");
    }

    public void OnExit()
    {

    }
}