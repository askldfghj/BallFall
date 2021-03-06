﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//オブジェクトプール　スクリプト
public class spawn : MonoBehaviour
{
    public static spawn _current;

    public Transform _player;
    public GameObject _floorSet;
    public GameObject _velcro;
    List<GameObject> _floorList;
    List<GameObject> _velcroList;

    public int _floorAmount;
    public int _velcroAmount;

    Vector3 _vec1;
    float _spawning;
    // Use this for initialization
    void Awake()
    {
        _velcroList = new List<GameObject>();
        _floorList = new List<GameObject>();
        _current = this;
    }

    void Start()
    {
        _vec1 = new Vector3(1, 1, 1);
        Time.timeScale = 0f;
        _spawning = _player.localPosition.y;
        StartCoroutine(CreatePool());      
    }

    IEnumerator CreatePool()
    {
        for (int i = 0; i < _floorAmount; i++)
        {
            GameObject floorset = (GameObject)Instantiate(_floorSet);

            floorset.transform.parent = transform;
            floorset.SetActive(false);
            _floorList.Add(floorset);
            yield return null;
        }

        for (int i = 0; i < _velcroAmount; i++)
        {
            GameObject velcro = (GameObject)Instantiate(_velcro);

            velcro.transform.parent = transform;
            velcro.SetActive(false);
            _velcroList.Add(velcro);
            yield return null;
        }

        InitStage();

        Time.timeScale = 1f;
    }

    public GameObject GetFloor()
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

    public GameObject GetVelcro()
    {
        for (int i = 0; i < _velcroList.Count; i++)
        {
            if (!_velcroList[i].activeInHierarchy)
            {
                return _velcroList[i];
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ステージの初期状態
    public void InitStage()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject floor = GetFloor();
            Vector3 _vec = _player.localPosition;
            _vec.x = 0;
            _vec.y -= 250 * (i + 1);
            _vec.x += Random.Range(-226, 227);
            floor.transform.parent = transform;
            floor.transform.localPosition = _vec;
            floor.transform.localScale = _vec1;
            floor.SetActive(true);
        }
    }

    public void PoolInActive()
    {
        for (int i = _floorList.Count - 1; i >= 0; i--)
        {
            _floorList[i].SetActive(false);
        }
        for (int i = _velcroList.Count - 1; i >= 0; i--)
        {
            _velcroList[i].SetActive(false);
        }
    }
}
