using UnityEngine;
using System.Collections;

public class wqegwgsd : MonoBehaviour
{
    Transform _player;
    // Use this for initialization
    public float _height;

    void Awake()
    {
        _player = GameObject.Find("Player").transform;
    }
    void OnEnable()
    {
        _height = _player.localPosition.y;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.localPosition.y < _height - 2000f)
        {
            InActive();
        }
    }

    void InActive()
    {
        gameObject.SetActive(false);
    }
}
