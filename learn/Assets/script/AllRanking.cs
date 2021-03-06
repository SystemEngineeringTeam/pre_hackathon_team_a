using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class AllRanking : MonoBehaviour
{
    public GameObject _gameMng;
    private GameMng gameMng;
    public Text highScoreText; //ハイスコアを表示するText
    private int[] highScore = new int[5]; //スコア用
    private string[] keyArray = {
        "HIGHSCORE" , "SECONDSCORE" , "THIRDSCORE" , "FORTHSCORE" , "FIFTHSCORE"
        }; //スコア保存先キー
    void Start(){
        _gameMng = GameObject.Find("GameMng");
        gameMng = _gameMng.GetComponent<GameMng>();
        highScore[0] = PlayerPrefs.GetInt(keyArray[0],0);
        highScore[1] = PlayerPrefs.GetInt(keyArray[1],0);
        highScore[2] = PlayerPrefs.GetInt(keyArray[2],0);
        highScore[3] = PlayerPrefs.GetInt(keyArray[3],0);
        highScore[4] = PlayerPrefs.GetInt(keyArray[4],0);
        //保存しておいたハイスコアをキーで呼び出し取得し、保存されていなければ0になる
        
        if(gameMng.getScore() > highScore[0]){
            highScore[1] = highScore[0];
            highScore[0] = gameMng.getScore(); //ハイスコア更新
            PlayerPrefs.SetInt(keyArray[0],highScore[0]);
            highScoreText.text = "HighScore: " + highScore[0].ToString();
            
        }
        highScoreText.text = "1位: " + highScore[0].ToString() + "\n" + "2位: " + highScore[1].ToString() + "\n" + "3位: " + highScore[2].ToString() + "\n" + "4位: " + highScore[3].ToString() + "\n" + "5位: " + highScore[4].ToString() + "\n";
        //ハイスコアを表示
    }
    void Update(){
        
    }
}