using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text bestScoreText;
    public GameManager manager;
    // Start is called before the first frame update
    void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        var asdf = Mathf.Floor(manager.playTime);
        scoreText.text = asdf.ToString();
        bestScoreText.text = PlayerPrefs.GetFloat("BestScore").ToString();

    }
}
