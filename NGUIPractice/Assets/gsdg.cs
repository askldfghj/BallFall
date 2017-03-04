using UnityEngine;
using System.Collections;

public class gsdg : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.acceleration.x;
        if (x < -1)
        {
            x = -1;
        }
        else if (x > 1)
        {
            x = 1;
        }
        transform.Translate(new Vector3(x,0,0) * 0.03f);
    }
}
