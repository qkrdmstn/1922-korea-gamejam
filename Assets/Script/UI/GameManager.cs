using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject clearUI;
    public GameObject overUI;
    public GameObject mapGauge;
    public GameObject HeartBoard;
    public GameObject socreBoard;


    private TMP_Text clearScore;
    private TMP_Text overScore;
    private TMP_Text scoreText;
    private TMP_Text bestScoreText;

    // Score
    public float playTime;
    public float curScore;

    public GameObject player;
    public ObstacleGenerator generator;

    // Start is called before the first frame update
    private void Awake()
    {
        AudioManager.instance.PlaySFX("Loop", true);
        AudioManager.instance.PlayBGM("BGM");
    }


    // Update is called once per frame
    void Update()
    {
        playTime += Time.deltaTime;
    }

    public void GameOver()
    {
        mapGauge.SetActive(false); //부수 UI 끄기
        HeartBoard.SetActive(false);
        socreBoard.SetActive(false);
        
        overUI.SetActive(true);
        scoreText = overUI.transform.GetChild(0).transform.Find("ScoreNumber").GetComponent<TMP_Text>();
        bestScoreText = overUI.transform.GetChild(0).transform.Find("HighScoreNumber").GetComponent<TMP_Text>();

       
        scoreText.text = curScore.ToString();
        bestScoreText.text = PlayerPrefs.GetFloat("BestScore").ToString();
        
    }

    public void LateGameOver()
    {
        Time.timeScale = 0;
    }

    public void GameClear()
    {
        mapGauge.SetActive(false); //부수 UI 끄기
        HeartBoard.SetActive(false);
        socreBoard.SetActive(false);

        curScore = playTime;
        if (curScore < PlayerPrefs.GetFloat("BestScore")) //(시간) 더 빨라야 좋은 기록
            PlayerPrefs.SetFloat("BestScore", curScore);

        clearUI.SetActive(true);

        scoreText = clearUI.transform.GetChild(0).transform.Find("ScoreNumber").GetComponent<TMP_Text>();
        bestScoreText = clearUI.transform.GetChild(0).transform.Find("HighScoreNumber").GetComponent<TMP_Text>();

        scoreText.text = curScore.ToString();
        bestScoreText.text = PlayerPrefs.GetFloat("BestScore").ToString();
    }

    public void LateGameClear()
    {
        Time.timeScale = 0;
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
        Time.timeScale = 1;
        playTime = 0;
        generator.index1 = 0;
        player.transform.position = new Vector3(0, 31, 0);

        Debug.Log("Init");
    }


}
