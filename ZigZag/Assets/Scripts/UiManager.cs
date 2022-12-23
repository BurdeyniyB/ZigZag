using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

    public static UiManager instance;

    public GameObject titlePanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public GameObject scoreGameObj;
    public GameObject diamondGameObj;
    public Text scoreGame;
    public Text diamondGame;
    public Text score;
    public Text highScore1;
    public Text highScore2;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

	void Start () {
        highScore1.text = "High Score: " + PlayerPrefs.GetInt("highScore");
    }

	void Update () {
		scoreGame.text = PlayerPrefs.GetInt("score").ToString();
		diamondGame.text = PlayerPrefs.GetInt("diamond").ToString();
	}

    public void GameStart()
    {
        tapText.SetActive(false);
        titlePanel.GetComponent<Animator>().Play("panelUp");
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("Level manager click", 1);
        SceneManager.LoadScene(0);
    }

    public void ActiveGameScore()
    {
      scoreGameObj.SetActive(true);
      diamondGameObj.SetActive(true);
    }
}
