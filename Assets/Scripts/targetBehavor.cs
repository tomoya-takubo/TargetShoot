using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class targetBehavor : MonoBehaviour
{
    public GameObject scoreTextPrefab;
    public string[] scores;

    private bool isCollided = false;
    private int ratio = 1;
    private AudioSource aud;
    private Collider2D col;
    private GameObject gmDirector;


    private void Start()
    {
        this.aud = GetComponent<AudioSource>();
        this.col = GetComponent<CircleCollider2D>();
        col.enabled = false;
        gmDirector = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        //的解放
        int dice = Random.Range(0, 200);
        //Debug.Log(dice);
        if (dice <= ratio)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
            col.enabled = true;
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
                //Debug.Log(transform.localScale);

            }
            else
            {
                targetLocalScale.x = 0;
                transform.localScale = targetLocalScale;
                //Debug.Log(targetLocalScale);
                isCollided = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //当たった！！
        isCollided = true;
        //コライダーOFF
        col.enabled = false;
        //的カウント
        gmDirector.GetComponent<GameDirector>().TargetHitCount();
        //SE
        this.aud.Play();
        //スコアテキスト表示
        GameObject scoreText = Instantiate(scoreTextPrefab
            , new Vector3(transform.position.x, transform.position.y + 1.3f, transform.position.z)
            , transform.rotation);
        //的と弾の距離
        float dis = Vector2.Distance(transform.position, collision.transform.position);
        //Debug.Log("的の位置：" + transform.position);
        //Debug.Log("弾の位置：" + collision.transform.position);
        //Debug.Log("距離は " + dis + " mです");
        //表示決定
        string score = "";
        if(dis > 0.7)
        {
            score = scores[0];
        }
        else if(dis <= 0.7 && dis > 0.3)
        {
            score = scores[1];
        }
        else if(dis <= 0.3)
        {
            score = scores[2];
        }
        scoreText.GetComponent<ScoreBehavor>().Setup(score);
    }
}
