using UnityEngine;
using System.Collections;

public class VelcroBody : MonoBehaviour {

    Transform _player;
    public VelcroContrl _head;
    bool _isright;
    void Awake()
    {
        _player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (_player.localPosition.y < transform.localPosition.y - 1000f)
        {
            InActive();
        }
    }

    public void SetBuildPosi(int a)
    {
        if (a == 0)
        {
            _isright = true;
        }
        else
        {
            _isright = false;
        }
        _head.SetBuildPosi(a);
    }

    void FixedUpdate()
    {
        if (_isright)
        {
            transform.Translate(Vector3.up * 0.01f);
        }
        else
        {
            transform.Translate(Vector3.down * 0.01f);
        }
    }

    void InActive()
    {
        gameObject.SetActive(false);
    }
}
