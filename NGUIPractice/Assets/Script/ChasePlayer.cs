using UnityEngine;
using System.Collections;

public class ChasePlayer : MonoBehaviour
{
    public GameObject _player;
    Vector3 _pos;
    float _offset;
    // Use this for initialization
    void Start()
    {
        _offset = transform.position.y - _player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (_offset < transform.position.y - _player.transform.position.y)
        {
            _pos.y = _player.transform.position.y + _offset;
            transform.position = _pos;
        }
    }
}
