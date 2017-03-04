using UnityEngine;
using System.Collections;

public class FloorContrl : MonoBehaviour
{
    Transform _player;
    GameObject _GM;
    GameMaster _master;

    Vector3 _vec1;
    Vector3 _spawnVec;
    bool _isCreate;

    void Awake()
    {
        _player = GameObject.Find("Player").transform;
        _GM = GameObject.Find("GM");
        _master = _GM.GetComponent<GameMaster>();
        _vec1 = new Vector3(1, 1, 1);
    }
    void OnEnable()
    {
        _isCreate = false;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.up * 0.01f);
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
    }
}
