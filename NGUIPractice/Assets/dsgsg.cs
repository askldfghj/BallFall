using UnityEngine;
using System.Collections;

public class dsgsg : MonoBehaviour
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
        _pos.y = _player.transform.position.y + _offset;
        transform.position = _pos;
    }
}
