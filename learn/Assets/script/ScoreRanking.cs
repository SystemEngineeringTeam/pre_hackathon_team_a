using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class ScoreRanking : MonoBehaviour
{
    public GameObject _gameMng;
    private GameMng gameMng;
    public Text highScoreText; //ハイスコアを表示するText
    private int highScore; //スコア用
    private string key1 = "HIGHSCORE"; //ハイスコア保存先キー

    void Start(){
        _gameMng = GameObject.Find("GameMng");
        gameMng = _gameMng.GetComponent<GameMng>();
        highScore = PlayerPrefs.GetInt(key1,0);
        //保存しておいたハイスコアをキーで呼び出し取得し、保存されていなければ0になる
        highScoreText.text = "HighScore: " + highScore.ToString();
        //ハイスコアを表示
    }
    void Update(){
        if(gameMng.getScore() > highScore){
            highScore = gameMng.getScore(); //ハイスコア更新
            PlayerPrefs.SetInt(key1,highScore);
            highScoreText.text = "HighScore: " + highScore.ToString();
        }
    }
}