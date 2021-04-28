using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleMethods : MonoBehaviour
{
    public void ToggleSize()
    {
        if (transform.localScale.x == 1f)
            transform.localScale = new Vector3(2, 2, 2);
        else
            transform.localScale = new Vector3(1, 1, 1);
    }
}
