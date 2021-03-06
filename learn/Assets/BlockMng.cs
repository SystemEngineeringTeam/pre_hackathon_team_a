using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMng : MonoBehaviour
{
    public GameObject block;
    float _timer = 0; //_timerの初期化
    float _totalTime = 0;
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
            GameObject obj = Instantiate(block, position, Quaternion.identity);
            //Instatiate[オブジェクトの生成](コピーする既存obj, 位置, 向き) Quaternion.identity -> 回転しない
            block blockScript = obj.GetComponent<block>();
            
            float speed = 100 + (_totalTime * 10);
            blockScript.SetSpeed(-speed);

            _timer += 1;
        }
    }
}
