using UnityEngine;
using System.Collections;

public class VelcroContrl : MonoBehaviour
{
    public Transform _line; //腕の Transform (オブジェクト)
    public Transform _bodypivot;
    public Transform _handpivot;
    public int distance; //腕の長さ
    Transform _player;

    BoxCollider2D _box2d; //box collider
    RaycastHit2D _hit; //Ray2D
    int _layerMask;

    Vector3 _initPosi;


    float _lineLength; //現在の腕の長さ (localposition)
    int _xPosi;

    //マシーンの状態
    bool _isAwake;
    bool _isStop;
    bool _isBack;
    bool _isHanded;
    bool _isRightStruct;
    
    void Awake()
    {
        _layerMask = 1 << 9;
        _initPosi = transform.localPosition;
        _box2d = GetComponent<BoxCollider2D>();
        _player = GameObject.Find("Player").transform;
    }

    void Start()
    {

    }

    void OnEnable()
    {
        transform.localPosition = _initPosi;
        _xPosi = 0;
        _isBack = false;
        _isStop = true;
        _isHanded = false;
        _isAwake = true;
        _box2d.enabled = false;
        _lineLength = 0f;
    }
    
    void FixedUpdate()
    {
        if (_isAwake)
        {
            if (!_isStop)
            {
                TurnOnMachine();
            }
            else
            {
                ContactPlayer();
            }
        }
    }

    void TurnOnMachine()
    {
        MoveHand();
        ChkLineLength();
        if (_xPosi > distance)
        {
            _isBack = true;
        }
    }

    void MoveHand()
    {
        if (!_isBack)
        {
            transform.Translate(Vector3.left * 0.03f);
            _xPosi++;
        }
        else
        {
            if (_isHanded)
            {
                DrawPlayer();
            }
            transform.Translate(Vector3.right * 0.03f);
        }
    }

    void DrawPlayer()
    {
        _player.position = transform.position;
    }

    void ContactPlayer()
    {
        if (_isRightStruct)
        {
            _hit = Physics2D.Raycast(transform.position, Vector2.left, 5f, _layerMask);
        }
        else
        {
            _hit = Physics2D.Raycast(transform.position, Vector2.right, 5f, _layerMask);
        }
        if (_hit.collider != null)
        {
            _isStop = false;
        }
        else
        {
            _box2d.enabled = true;
        }
    }

    void ChkLineLength()
    {
        _lineLength = Signchk(_bodypivot.localPosition.x - _handpivot.localPosition.x);
        if (_isBack && _lineLength <= 30f)
        {
            StopProcess();
        }
    }

    void StopProcess()
    {
        _isStop = true;
        _isAwake = false;
        _box2d.enabled = false;
        if (_isHanded)
        {
            _player.SendMessage("SetVelcro");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && !_isHanded)
        {
            _isHanded = true;
            _isBack = true;
            _player.SendMessage("SetVelcro");
            _box2d.enabled = false;
        }
    }

    float Signchk(float a)
    {
        if (a < 0)
        {
            return (-a);
        }
        return a;
    }

    public void SetBuildPosi(int a)
    {
        if (a == 0)
        {
            _isRightStruct = true;
        }
        else
        {
            _isRightStruct = false;
        }
    }
}
