using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;
    public int score;
    public int diamond;
    public int highScore;

	void Awake () {
        if (instance == null)
            instance = this;
	}

    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);
        diamond = PlayerPrefs.GetInt("diamond");
    }

    void Update () {
		PlayerPrefs.SetInt("score", score);
		PlayerPrefs.SetInt("diamond", diamond);
	}

    public void IncrementScore()
    {
        score += 1;
    }

    public void DiamondScore()
    {
        diamond += 1;
    }

    public void StopScore()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            if(score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        else // create highScore key and set their score as it.
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
