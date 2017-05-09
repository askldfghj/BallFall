using UnityEngine;
using System.Collections;

//各層の管理スクリプト
public class FloorContrl : MonoBehaviour
{
    Transform _player;
    GameObject _GM;
    GameMaster _master;


    Vector3 _vec1;
    Vector3 _spawnVec;
    bool _isCreate;

    Transform _leftVelcro;
    Transform _rightVelcro;
    Quaternion _velrot;

    int _velcrochance;

    void Awake()
    {
        _player = GameObject.Find("Player").transform;
        _GM = GameObject.Find("GM");
        _rightVelcro = GameObject.Find("RightVelcro").transform;
        _leftVelcro = GameObject.Find("LeftVelcro").transform;
        _master = _GM.GetComponent<GameMaster>();
        _vec1 = new Vector3(1, 1, 1);
        _velrot = Quaternion.Euler(0, 0, 180);
    }
    void OnEnable()
    {
        _isCreate = false;
    }
    void Start()
    {
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.up * 0.01f * ((_master.GetScore() / 100 + 1) * 0.5f) );
    }

    void Update()
    {
        if (_player.localPosition.y < transform.localPosition.y - 1000f)
        {
            InActive();
        }
    }

    void InActive()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (!_isCreate)
            {
                CreateFloor();
                _master.ScoreUp();
            }
        }

    }

    //floorとVelcroをオブジェクトプールから作る
    void CreateFloor()
    {
        _isCreate = true;
        GameObject floor = spawn._current.GetFloor();
        if (floor == null) return;
        _spawnVec.y = transform.localPosition.y - 1250f;
        _spawnVec.x = Random.Range(-226, 227);
        floor.transform.localPosition = _spawnVec;
        floor.transform.localScale = _vec1;
        floor.SetActive(true);

        _velcrochance = Random.Range(0, 11);
        if (_velcrochance >= 7)
        {
            GameObject velcro = spawn._current.GetVelcro();
            if (velcro == null) return;
            int ran = Random.Range(0, 2);
            VelcroBody velctrl = velcro.GetComponent<VelcroBody>();
            VelcroSetting(ran, velcro);
            velcro.transform.localScale = _vec1;
            velcro.SetActive(true);
            velctrl.SetBuildPosi(ran);
        }
    }

    //velcroの位置を決める
    void VelcroSetting(int ran, GameObject velcro)
    {
        if (ran == 0)
        {
            velcro.transform.localPosition = new Vector3(337f, _spawnVec.y + 88f, 0);
            velcro.transform.localRotation = Quaternion.identity;
        }
        else
        {
            velcro.transform.localPosition = new Vector3(-337f, _spawnVec.y + 88f, 0);
            velcro.transform.localRotation = _velrot;
        }
    }
}
