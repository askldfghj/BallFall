using UnityEngine;
using System.Collections;

//プレイヤーに関するスクリプト
public class PlayerContrl : MonoBehaviour
{
    bool _isVelcroed;
    Vector3 _vec;
    Rigidbody2D _rb2D;

    void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _vec = Vector3.zero;
        SetInit();
    }

    public void SetInit()
    {
        _isVelcroed = false;
        _rb2D.gravityScale = 1;
    }

    // Use this for initialization
    void Start()
    {
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
            _rb2D.gravityScale = 0;
        }
        else
        {
            _isVelcroed = false;
            _rb2D.gravityScale = 1;
        }
    }
}
