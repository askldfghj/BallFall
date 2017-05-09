using UnityEngine;
using System.Collections;

//velcroのボディーに関するスクリプト
public class VelcroBody : MonoBehaviour {

    GameMaster _GM;
    Transform _player;
    public VelcroContrl _head;
    bool _isright;
    void Awake()
    {
        _GM = GameObject.Find("GM").GetComponent<GameMaster>();
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
            transform.Translate(Vector3.up * 0.01f * ((_GM.GetScore()/100 + 1) * 0.5f));
        }
        else
        {
            transform.Translate(Vector3.down * 0.01f * ((_GM.GetScore() / 100 + 1) * 0.5f));
        }
    }

    void InActive()
    {
        gameObject.SetActive(false);
    }
}
