using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehabor : MonoBehaviour
{
    //タイムカウンター
    float timeCntr = 0;
    //スケール変更用変数
    Vector3 scale;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //時間更新
        timeCntr += Time.deltaTime;
        float dcrs = 1 - 1.5f * timeCntr;
        //スケール計算
        scale = new Vector3(dcrs, dcrs, dcrs);
        //スケール変更
        if(scale.x > 0.1)   //スケール値減少
        {
            transform.localScale = scale;
        }
        else if (scale.x < 0.05 && scale.x > 0)  //コライダーON
        {
            GetComponent<CircleCollider2D>().enabled = true;
            //transform.localScale = scale;
        }
        else if(scale.x < 0)    //自オブジェクトを破壊
        {
            Destroy(gameObject);
        }

    }
}
