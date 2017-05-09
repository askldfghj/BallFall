using UnityEngine;
using System.Collections.Generic;

//ゲームステージに関するスクリプト
public class GameMaster : MonoBehaviour
{
    public UILabel _scoreboard;
    public UILabel _resultboard;
    public GameObject _result;
    public GameObject _pause;
    public PlayerContrl _player;
    public List<InitContrl> _InitObjList;

    bool _isPause;
    bool _isOver;
    int _score;

    void Start()
    {
        _isPause = false;
        _isOver = false;
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
            _isPause = true;
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
        if (!_isPause)
        {
            _result.SetActive(false);
            _score = 0;
            _scoreboard.text = _score.ToString();
            spawn._current.PoolInActive();
            for (int i = 0; i < _InitObjList.Count; i++)
            {
                _InitObjList[i].InitObject();
            }
            transform.position = Vector3.zero;
            spawn._current.InitStage();
            _player.SetInit();
            Time.timeScale = 1f;
            _isOver = false;
        }
    }

    public void PauseCancel()
    {
        _pause.SetActive(false);
        _isPause = false;
        if (!_isOver)
        {
            Time.timeScale = 1f;
        }
    }

    public void QuitProcess()
    {
        Application.LoadLevel("0_start");
    }

    public void IsOver()
    {
        _isOver = true;
    }

    public int GetScore()
    {
        return _score;
    }
}
