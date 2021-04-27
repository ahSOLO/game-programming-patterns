using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public Vector3 ReadInput()
    {
        float x = 0;
        if (Input.GetKey(KeyCode.A))
            x = -1;
        else if (Input.GetKey(KeyCode.D))
            x = 1;

        float y = 0;
        if (Input.GetKey(KeyCode.S))
            y = -1;
        else if (Input.GetKey(KeyCode.W))
            y = 1;

        if (x != 0 || y != 0)
        {
            Vector3 dir = new Vector3(x, y, 0);
            return dir;
        }
        return Vector3.zero;
    }
    
    public bool ReadUndo()
    {
        return Input.GetKey(KeyCode.Backspace);
    }

    public bool ReadRedo()
    {
        return Input.GetKey(KeyCode.Y);
    }

    public float ReadScale()
    {
        if (Input.GetKey(KeyCode.E))
        {
            return 1f;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            return -1f;
        }

        return 0f;
    }
}
