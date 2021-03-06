using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    //これがあると、いちいちスクリプトを開いて変数を変更しなくてよくなる。Unity内から変えられるようになる
    float JUMP_VELOCITY = 1000;
    //JUMP_VELOCITYという変数を用意

    public GameObject gameMng;


    Rigidbody2D _rigidbody;
    //物理挙動コンポーネント。Rigidbody2Dを保持する変数の定義。コンポーネントを取得する関数は処理が重いので、あらかじめ保持しておくと良い
    GameMng _gameMng; // ②ゲーム管理スクリプト

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        //スタート時に、上の物理挙動コンポーネントを取得する

        gameMng = GameObject.Find("GameMng");

        _gameMng = gameMng.GetComponent<GameMng>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            //スペースキーが押された時
            _rigidbody.velocity = Vector2.zero;
            // 落下速度を一度リセット（ゼロに）する
            _rigidbody.AddForce(new Vector2(0, JUMP_VELOCITY));
            // 上方向にJUMP_VELOCITYで定義した分の力を加える
        }
    }

    private void FixedUpdate(){
        // 座標を取得
        Vector3 position = transform.position;
        // 画面外に出ないようにする
        float y = transform.position.y;
        float vx = _rigidbody.velocity.x;
        if(y > GetTop()){
            _rigidbody.velocity = Vector2.zero;
            //速度リセット
            position.y = GetTop();
            // 押し戻し
        }
        if(y < GetBottom()){
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(new Vector2(0,JUMP_VELOCITY));
            position.y = GetBottom();
        }
        transform.position = position;
    }
    float GetTop(){
        Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);
        return max.y;
    }
    float GetBottom(){
        Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        return min.y;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // ④ゲームオーバーを通知
        if(collision.tag == "dead"){    //deadタグを持つblockと衝突 
            _gameMng.StartGameOver();
            // 衝突したので消滅
            Destroy(gameObject);
        }else if(collision.tag == "addpoint"){  //addpointタグを持つsetと衝突
            _gameMng.GetPoint();
        }
    }
}
