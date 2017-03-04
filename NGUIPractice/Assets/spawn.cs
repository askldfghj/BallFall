using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawn : MonoBehaviour
{
    public Transform _player;
    public GameObject _floorSet;
    List<GameObject> _floorList;

    public int _floorAmount;

    float _spawning;
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 0f;
        _floorList = new List<GameObject>();
        _spawning = _player.localPosition.y;
        StartCoroutine(CreatePool());      
    }

    IEnumerator CreatePool()
    {
        for (int i = 0; i < _floorAmount; i++)
        {
            GameObject enemybullet = (GameObject)Instantiate(_floorSet);

            enemybullet.transform.parent = transform; //Pool오브젝트를 부모로 삼도록 한다.
            enemybullet.SetActive(false);
            _floorList.Add(enemybullet);
            //비활성후 리스트 추가
            yield return null;
        }

        for (int i = 0; i < 5; i++)
        {
            GameObject floor = GetFloor();
            Vector3 _vec = _player.localPosition;
            _vec.x = 0;
            _vec.y -= 250 * (i + 1);
            _vec.x += Random.Range(-226, 227);
            floor.transform.parent = transform;
            floor.transform.localPosition = _vec;
            floor.transform.localScale = new Vector3(1, 1, 1);
            floor.SetActive(true);
        }

        Time.timeScale = 1f;
    }

    GameObject GetFloor()
    {
        for (int i = 0; i < _floorList.Count; i++)
        {
            if (!_floorList[i].activeInHierarchy)
            {
                return _floorList[i];
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.localPosition.y < _spawning - 250)
        {
            CreateFloor();
            _spawning = _player.localPosition.y;
        }
    }

    void CreateFloor()
    {
        GameObject floor = GetFloor();
        if (floor == null) return;
        Vector3 _vec = _player.localPosition;
        _vec.x = 0;
        _vec.y -= 1250;
        _vec.x += Random.Range(-226, 227);
        floor.transform.parent = transform;
        floor.transform.localPosition = _vec;
        floor.transform.localScale = new Vector3(1, 1, 1);
        floor.SetActive(true);
    }

    public void Dispose()
    {
        for (int i = _floorList.Count - 1; i >= 0; i--)
        {
            Destroy(_floorList[i]);
        }
    }
}
