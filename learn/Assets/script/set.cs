using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    float _speed = -100; // 移動速度の設定

    void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
        // 物理挙動を取得
        
        _rigidbody.AddForce(new Vector2(_speed, 0));  
        // 左向きに力を加える
    }

    void Update()
    {
        Vector2 position = transform.position;
        if(position.x < GetLeft()){
            Destroy(gameObject);　//オブジェクトの削除
        }
    }

    float GetLeft(){
        Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        //画面左のワールド座標の取得;
        return min.x;
    }

    public void SetSpeed(float speed){
        _speed = speed;
    }
}
