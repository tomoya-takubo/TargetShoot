using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class targetBehavor : MonoBehaviour
{
    private float cnt = 0;
    private bool isCollided = false;
    private int ratio = 1;
    private bool rightClicked = false;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rightClicked);

        if (this.rightClicked)
        {
            //的解放
            int dice = Random.Range(0, 200);
            //Debug.Log(dice);
            if (dice <= ratio)
            {
                this.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        //弾ヒット時の挙動
        if (isCollided)
        {
            float rot = 0.2f;
            Vector3 targetLocalScale = transform.localScale;
            if(targetLocalScale.x > 0.01f)
            {
                //回転
                targetLocalScale.x -= rot;
                transform.localScale = targetLocalScale;
                Debug.Log(transform.localScale);
            }
            else
            {
                targetLocalScale.x = 0;
                transform.localScale = targetLocalScale;
                //Debug.Log(targetLocalScale);
                isCollided = false;
            }
        }

        //（デバッグ用）右クリックで・・・
        if (Input.GetMouseButtonDown(1))
        {
            //的表示
            //transform.localScale = new Vector3(1, 1, 1);

            //ランダム表示開始
            this.rightClicked = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroy(gameObject);
        isCollided = true;
    }
}
