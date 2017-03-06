using UnityEngine;
using System.Collections;

public class TopWallContrl : MonoBehaviour
{
    public GameMaster _GM;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            _GM.GameOver();
        }
    }
}
