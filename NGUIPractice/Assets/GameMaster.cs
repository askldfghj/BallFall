using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour
{
    public UILabel _scoreboard;
    public UILabel _resultboard;
    public GameObject _result;
    int _score;
    // Use this for initialization
    void Start()
    {
        _score = 0;
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
        Time.timeScale = 1f;
        _result.SetActive(false);
        Application.LoadLevel("1_play");
    }
}
