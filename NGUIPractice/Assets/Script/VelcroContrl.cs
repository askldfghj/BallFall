using UnityEngine;
using System.Collections;

public class VelcroContrl : MonoBehaviour
{
    public Transform _line; //팔의 Transform (오브젝트)
    public Transform _bodypivot;
    public Transform _handpivot;
    public int distance; //팔이 뻗을수 있는 길이(update당 1 증가)
    Transform _player;

    BoxCollider2D _box2d; //box collider
    RaycastHit2D _hit; //Ray2D
    int _layerMask; //Ray2D에 넣을 레이어 마스크

    Vector3 _initPosi; //핸드의 초기 포지션


    float _lineLength; //현재 팔 길이 (localposition)
    int _xPosi; //현재 팔 길이 (쉬운 거리)

    bool _isAwake; //머신이 깨어남의 여부
    bool _isStop; //팔의 기동 여부
    bool _isBack; //팔 움직임 방향의 여부
    bool _isHanded; //플레이어 잡음의 여부
    bool _isRightStruct; //오른쪽 왼쪽 설치방향의 여부

    // Use this for initialization
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

    // Update is called once per frame
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
