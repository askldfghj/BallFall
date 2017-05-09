using UnityEngine;
using System.Collections;

//初期位置
public class InitContrl : MonoBehaviour
{
    Vector3 _initPosi;
    void Awake()
    {
        _initPosi = transform.position;
    }

    public void InitObject()
    {
        transform.position = _initPosi;
    }
}
