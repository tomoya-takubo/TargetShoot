using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehabor : MonoBehaviour
{
    float scale = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //弾発射
        Shoot();
    }

    void Shoot()
    {
        scale -= 1.5f * Time.deltaTime;
        if (scale > 0.25)   //スケール値減少
        {
            transform.localScale = new Vector3(scale, scale, scale);
        }
        else if (scale <= 0.25 && scale >= 0)  //コライダーON
        {
            GetComponent<CircleCollider2D>().enabled = true;
            //transform.localScale = scale;
        }
        else if (scale < 0)    //自オブジェクトを破壊
        {
            Destroy(gameObject);
        }
    }
}
