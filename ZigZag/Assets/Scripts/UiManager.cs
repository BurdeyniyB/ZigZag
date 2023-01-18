using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

    public static UiManager instance;

    public GameObject title_Panel;
    public GameObject game_Over_Panel;
    public GameObject tap_Text;
    public GameObject score_Game_Obj;
    public GameObject diamond_Game_Obj;
    public Text Score_Game;
    public Text Diamond_Game;
    public Text Score;
    public Text High_Score_1;
    public Text High_Score_2;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

	void Start () {
        High_Score_1.text = "High Score: " + PlayerPrefs.GetInt("highScore");
    }

	void Update () {
		Score_Game.text = PlayerPrefs.GetInt("score").ToString();
		Diamond_Game.text = PlayerPrefs.GetInt("diamond").ToString();
	}

    public void GameStart()
    {
        tap_Text.SetActive(false);
        title_Panel.GetComponent<Animator>().Play("panelUp");
    }

    public void GameOver()
    {
        Score.text = PlayerPrefs.GetInt("score").ToString();
        High_Score_2.text = PlayerPrefs.GetInt("highScore").ToString();
        game_Over_Panel.SetActive(true);
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("Level manager click", 1);
        SceneManager.LoadScene(0);
    }

    public void ActiveGameScore()
    {
      score_Game_Obj.SetActive(true);
      diamond_Game_Obj.SetActive(true);
    }
}
