using UnityEngine;
using System.Collections;

public class VelcroContrl : MonoBehaviour
{
    public Transform _line;
    public int distance;
    Transform _player;

    BoxCollider2D _box2d;
    RaycastHit2D _hit;
    int _layerMask;

    Vector3 _initPosi;
    Vector3 _scale;
    Vector3 _initscale;

    float _lineLength;
    float _time;
    int _initx;
    bool _isBack;
    bool _isStop;
    bool _isHanded;
    bool _isAwake;
    bool _isRightStruct;
    // Use this for initialization
    void Awake()
    {
        _layerMask = 1 << 9;
        _scale = _line.localScale;
        _initscale = _line.localScale;
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
        _line.localScale = _initscale;
        _scale = _line.localScale;
        _initx = 0;
        _time = Time.time;
        _isBack = false;
        _isStop = true;
        _isHanded = false;
        _isAwake = true;
        _box2d.enabled = true;
        _lineLength = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAwake)
        {
            if (!_isStop)
            {
                MoveHand();
                ArrangeLine();
                if (_initx > distance)
                {
                    _isBack = true;
                }
            }
            else
            {
                ContactPlayer();
            }
        }
    }

    void MoveHand()
    {
        if (!_isBack)
        {
            transform.Translate(Vector3.left * 0.03f);
            _initx++;
        }
        else
        {
            if (_isHanded)
            {
                _player.position = transform.position;
            }
            transform.Translate(Vector3.right * 0.03f);
        }
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
    }

    void ArrangeLine()
    {
        _lineLength = Signchk(transform.localPosition.x);
        _scale.x = _lineLength * 0.025f - 0.5f;
        _line.localScale = _scale;
        if (_isBack && _lineLength <= 1f)
        {
            _isStop = true;
            _isAwake = false;
            if (_isHanded)
            {
                _player.SendMessage("SetVelcro");
                _isHanded = false;
            }
            _line.localScale = Vector3.zero;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
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
