using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour
{
    WaitForSeconds _waitsec;
    public UILabel _label;
    // Use this for initialization
    void Awake()
    {
        _waitsec = new WaitForSeconds(1f);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KeyProcess();
    }

    void KeyProcess()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    IEnumerator BlinkText()
    {
        while (true)
        {
            _label.enabled = true;
            yield return _waitsec;
            _label.enabled = false;
            yield return _waitsec;
        }
    }

    void OnEnable()
    {
        StartCoroutine(BlinkText());
    }


    public void StartGame()
    {
        Application.LoadLevel("1_play");
    }
}
