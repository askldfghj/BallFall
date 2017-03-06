using UnityEngine;
using System.Collections.Generic;

public class GameMaster : MonoBehaviour
{
    public UILabel _scoreboard;
    public UILabel _resultboard;
    public GameObject _result;
    public GameObject _pause;
    public PlayerContrl _player;
    public List<InitContrl> _InitObjList;
    int _score;
    // Use this for initialization

    void Start()
    {
        _score = 0;
    }

    void Update()
    {
        KeyProcess();
    }

    void KeyProcess()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            _pause.SetActive(true);
        }
    }

    public void ScoreUp()
    {
        _score++;
        _scoreboard.text = _score.ToString();
    }

    public void GameOver()
    {
        _result.SetActive(true);
        _resultboard.text = _score.ToString();
        Time.timeScale = 0f;
    }

    public void ReGame()
    {
        _result.SetActive(false);
        //Application.LoadLevel("1_play");
        _score = 0;
        spawn._current.PoolInActive();
        for (int i = 0; i < _InitObjList.Count; i++)
        {
            _InitObjList[i].InitObject();
        }
        transform.position = Vector3.zero;
        spawn._current.InitStage();
        _player.SetInit();
        Time.timeScale = 1f;
    }

    public void PauseCancel()
    {
        Time.timeScale = 1f;
        _pause.SetActive(false);
    }

    public void QuitProcess()
    {
        Application.LoadLevel("0_start");
    }

    public int GetScore()
    {
        return _score;
    }
}
