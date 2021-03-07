using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMng : MonoBehaviour
{
    public GameObject block;
    public GameObject gamemng;
    float _timer = 0; //_timerの初期化
    float _totalTime = 0;
   　GameMng scores;
    int _cnt = 0;
    int _ud = 0; //ブロックが上に生成された->0 下に生成された->1
    void Start()
    {
        
    }

    void Update()
    {
        _timer -= Time.deltaTime;
       //Time.deltaTime -> 直前のフレームと今のフレーム間で経過した時間[秒]を返す 

       _totalTime += Time.deltaTime;

        if(_timer < 0){
            Vector3 position = transform.position;
            //BlockMngから生成
            if(_ud == 0){    //ブロックを下に生成する
                position.y = Random.Range(-6, 0);
                _ud = 1;
            }else{      //ブロックを上に生成する
                position.y = Random.Range(0, 6);
                _ud = 0;
            }

            GameObject obj = Instantiate(block, position, Quaternion.identity);
            //Instatiate[オブジェクトの生成](コピーする既存obj, 位置, 向き) Quaternion.identity -> 回転しない
            block blockScript = obj.GetComponent<block>();

            float speed = 100 + (_totalTime * 10);
            blockScript.SetSpeed(-speed);

            scores = gamemng.GetComponent<GameMng>();
            int score = scores.getScore();

            _cnt++;
            if(_cnt%3 == 0 && score > 500 && score <1000){
                _timer += 0.1f;
            }else if(_cnt%3 == 0 && score >= 1000){
                _timer += 0.1f;
            }else{
                _timer += 1;
                if(score > 1000){
                    _timer -= 0.5f;
                }
            }
        }
    }
}
