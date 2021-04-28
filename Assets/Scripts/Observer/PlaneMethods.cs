using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMethods : MonoBehaviour
{
    public Event collisionEvent;

    private void OnCollisionEnter(Collision collision)
    {
        collisionEvent.Occurred();
    }
}
