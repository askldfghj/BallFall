using UnityEngine;
using System.Collections;

//一定距離下がったプレイヤーの位置を追う
public class ChasePlayer : MonoBehaviour
{
    public GameObject _player;
    Vector3 _pos;
    float _offset;
    void Start()
    {
        _offset = transform.position.y - _player.transform.position.y;
    }
    
    void Update()
    {
        if (_offset < transform.position.y - _player.transform.position.y)
        {
            _pos.y = _player.transform.position.y + _offset;
            transform.position = _pos;
        }
    }
}
