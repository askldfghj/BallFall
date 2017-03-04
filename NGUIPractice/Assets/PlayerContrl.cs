using UnityEngine;
using System.Collections;

public class PlayerContrl : MonoBehaviour
{
    Vector3 _vec;
    // Use this for initialization
    void Start()
    {
        _vec = Vector3.zero;
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
        _vec.x = x;
        transform.Translate(_vec * 0.03f * 1.5f);
    }
}
