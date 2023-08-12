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

    // Score
    public float playTime;
    public GameObject player;
    public ObstacleGenerator generator;

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        playTime += Time.deltaTime;
    }

    public void GameOver()
    {
        mapGauge.SetActive(false); //ºÎ¼ö UI ²ô±â
        HeartBoard.SetActive(false);
        socreBoard.SetActive(false);

        overUI.SetActive(true);
        Time.timeScale = 0;
        scoreText = overUI.transform.GetChild(0).transform.Find("Score").GetComponent<TMP_Text>();
    }

    public void GameClear()
    {
        mapGauge.SetActive(false); //ºÎ¼ö UI ²ô±â
        HeartBoard.SetActive(false);
        socreBoard.SetActive(false);

        Time.timeScale = 0;
        clearUI.SetActive(true);
        scoreText = clearUI.transform.GetChild(0).transform.Find("Score").GetComponent<TMP_Text>();
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
