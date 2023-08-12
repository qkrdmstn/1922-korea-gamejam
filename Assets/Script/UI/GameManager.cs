using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public GameObject clearUI;
    public GameObject overUI;
    public TMP_Text clearScore;
    public TMP_Text overScore;
    public int score;
    public float playTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.O))
            GameOver();
        if (Input.GetKey(KeyCode.P))
            GameClear();

        playTime += Time.deltaTime;
    }

    public void GameOver()
    {
        
        overUI.SetActive(true);
  
        overScore.text = score.ToString();
        Time.timeScale = 0;
    }

    public void GameClear()
    {
        Time.timeScale = 0;
        clearUI.SetActive(true);
        clearScore.text = score.ToString();
    }

    public void SetPause()
    {
        Time.timeScale = 0f;

    }

    public void SetPlaying()
    {
        Time.timeScale = 1.0f;
    }

    public void GameRestart()
    {
        Initialized();
    }

    public void GameExit()
    {
        Debug.Log("Exit");
        SceneManager.LoadScene("Title");
    }

    public void Initialized()
    {
        score = 0;
        playTime = 0;
        Debug.Log("Init");
    }
}
