using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public GameObject clearUI;
    public GameObject overUI;
    public TMP_Text clearScore;
    public TMP_Text overScore;
    public int score;
    

    private void Awake()
    {
        if (null == instance) //ΩÃ±€≈Ê
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

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
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        overUI.SetActive(true);
        overScore.text = score.ToString();
       
    }

    public void GameClear()
    {
        Time.timeScale = 0;
        clearUI.SetActive(true);
        clearScore.text = score.ToString();
    }

    public void SetPause()
    {
        Time.timeScale = 0;

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
        Debug.Log("Init");
    }
}
