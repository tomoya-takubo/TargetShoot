using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class targetBehavor : MonoBehaviour
{
    public GameObject scoreTextPrefab;
    public string[] scores;
    public int[] scorePoints;
    public float rotationSpeed = 0.5f;

    private bool isCollided = false;
    private int ratio = 1;
    private AudioSource aud;
    private Collider2D col;
    //private GameObject gmDirector;
    private GameDirector_ScoreCountVer gmDirector;


    private void Start()
    {
        this.aud = GetComponent<AudioSource>();
        this.col = GetComponent<CircleCollider2D>();
        col.enabled = false;
        //gmDirector = GameObject.Find("GameDirector");
        gmDirector 
            = GameObject.FindGameObjectWithTag("GameDirector").GetComponent<GameDirector_ScoreCountVer>();
    }

    // Update is called once per frame
    void Update()
    {
        //的解放
        Appeared();

        //弾ヒット時の挙動
        Hit();
    }

    public void Appeared()
    {
        int dice = Random.Range(0, 200);
        //Debug.Log(dice);
        if (dice <= ratio)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
            col.enabled = true;
        }
    }

    public void Hit()
    {
        if (isCollided)
        {
            Vector3 targetLocalScale = transform.localScale;
            //回転
            targetLocalScale.x -= rotationSpeed;    // * Time.deltaTime;
            if(targetLocalScale.x >= -1)
            {
                transform.localScale = targetLocalScale;
                if (transform.localScale.x <= -1)
                {
                    Debug.Log("transform.localScale.x：" + transform.localScale.x);
                    targetLocalScale.x = 1;
                    transform.localScale = targetLocalScale;
                }
            }
            /***
            else
            {
                targetLocalScale.x = 1;
                transform.localScale = targetLocalScale;
            }
            ***/

            /***
            if (targetLocalScale.x > 0.01f)
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
            ***/
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //当たった！！
        isCollided = true;
        //コライダーOFF
        col.enabled = false;
        //的カウント
        //gmDirector.GetComponent<GameDirector>().TargetHitCount();
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
        int scorePoint = 0;
        if(dis > 0.7)
        {
            score = scores[0];
            scorePoint = scorePoints[0];
        }
        else if(dis <= 0.7 && dis > 0.3)
        {
            score = scores[1];
            scorePoint = scorePoints[1];
        }
        else if(dis <= 0.3)
        {
            score = scores[2];
            scorePoint = scorePoints[2];
        }
        scoreText.GetComponent<ScoreBehavor>().Setup(score);
        gmDirector.UpdateScore(scorePoint);
    }
}
