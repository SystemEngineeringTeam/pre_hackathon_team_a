using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
// UI

using UnityEngine.SceneManagement;
// シーンの読み直しに必要

public class GameMng : MonoBehaviour {
  
    enum State {
        Main, // メインゲーム
        GameOver, // ゲームオーバー
    }

    public GUISkin customSkin;　//GUISkinを格納

    int _score = 0;
    int _point = 0;
    //スコア
    public int getScore(){
        return _score;
    }
    State _state = State.Main;
    //スコア

    // ゲームオーバーの開始
    public void StartGameOver() {
        _state = State.GameOver;
    }

    public void GetPoint(){ //pointを加算する
        _point++;
    }

    void Start() {
    }

    void Update() {
    }

    private void FixedUpdate() {
     if(_state == State.Main) {  // メインゲーム中のみスコア上昇
            _score += 1;
        }
    } 

    private void OnGUI() {
        // スコアの描画
        _DrawScore();
        _DrawPoint();

        GUI.skin = customSkin;　//GUISkinを呼び出し

        // 画面の中心座標を計算する
        float CenterX = Screen.width / 2;
        float CenterY = Screen.height / 2;
        if(_state == State.GameOver) {
            // ゲームオーバーの描画
            _DrawGameOver(CenterX, CenterY);
            // ②リトライボタンの描画
            if(_DrawRetryButton(CenterX, CenterY)) {
                // ③クリックしたらやり直しする
                SceneManager.LoadScene("Scenes/naruse01");
            }
            // ランキングボタンの描画
            if(_DrawRankingButton(CenterX, CenterY)) {
                // クリックしたらランキング画面へ
                SceneManager.LoadScene("Scenes/ranking");
            }
        }
    }  

  // ④リトライボタンの描画
    bool _DrawRetryButton(float CenterX, float CenterY) {
        float ofsY = 70;
        float w = 200;
        float h = 90;
        Rect rect = new Rect(CenterX - w / 2, CenterY + ofsY, w, h);
        if (GUI.Button(rect, "RETRY")) {
        // ボタンを押した
        return true;
        }
        return false;
    }

    // ランキングボタンの描画
    bool _DrawRankingButton(float CenterX, float CenterY) {
        float ofsY = 180;
        float w = 200;
        float h = 90;
        Rect rect = new Rect(CenterX - w / 2, CenterY + ofsY, w, h);
        if (GUI.Button(rect, "RANKING")) {
        // ボタンを押した
        return true;
        }
        return false;
    }

  // ゲームオーバーの描画
    void _DrawGameOver(float CenterX, float CenterY) {
        // 中央揃え
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        float w = 1000;
        float h = 200;
        // 文字を大きくする
        GUI.skin.label.fontSize = 110;
        Rect position = new Rect(CenterX - w / 2, CenterY - h / 2 - 50, w, h);
        GUI.Label(position, "GAME OVER");
    }

  // スコアの描画
    void _DrawScore() {
        // 文字を大きくする
        GUI.skin.label.fontSize = 40;
        // 左揃え
        GUI.skin.label.alignment = TextAnchor.MiddleLeft;
        Rect position = new Rect(8, 8, 400, 100);
        GUI.Label(position, string.Format("score:{0}", _score));
    }

    //pointの描画
    void _DrawPoint(){
        GUI.skin.label.fontSize = 32;
        // 左揃え
        GUI.skin.label.alignment = TextAnchor.MiddleLeft;
        Rect position = new Rect(8, -20, 400, 100);
        GUI.Label(position, string.Format("point:{0}", _point));
    }
}