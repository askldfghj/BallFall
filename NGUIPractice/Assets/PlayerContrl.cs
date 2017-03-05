using UnityEngine;
using System.Collections;

public class PlayerContrl : MonoBehaviour
{
    bool _isVelcroed;
    Vector3 _vec;
    // Use this for initialization
    void Start()
    {
        _isVelcroed = false;
        _vec = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!_isVelcroed)
        {
            MoveBall();
        }
    }

    void MoveBall()
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

    public void SetVelcro()
    {
        if (!_isVelcroed)
        {
            _isVelcroed = true;
        }
        else
        {
            _isVelcroed = false;
        }
    }
}
