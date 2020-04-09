using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector_ScoreCountVer : MonoBehaviour
{
    //GameObject remainingTime;     //Find関数はUnityの中でも屈指の重さを誇る関数のため使用を避けます
    public Text remainingTime;
    public Text Score;
    public Text Target;
    public float time = 60f;
    public GameObject panel;    //リザルト画面
    public bool timeup = false;
    int scoreCount = 0;
    int targetCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //remainingTime = GameObject.Find("RemainingTime"); //Find関数はUnityの中でも屈指の重さを誇る関数のため使用を避けます
    }

    // Update is called once per frame
    void Update()
    {
        if (!timeup)
        {
            //時間更新
            time -= Time.deltaTime;
            if (time < 0)
            {
                time = 0f;
                timeup = true;
            }
        }
        else
        {
            panel.SetActive(true);
            panel.transform.GetChild(0).GetComponent<Text>().text
                = "Target × " + targetCount 
                + "\n" 
                + "Score " + scoreCount;
        }
        /***
        remainingTime.GetComponent<Text>().text
            = time.ToString("F2");
        ***/
        remainingTime.text = time.ToString("F2");

    }

    //スコア更新
    public void UpdateScore(int score)
    {
        scoreCount += score;
        Score.text = scoreCount.ToString();
    }

    //的破壊更新
    public void UpdateTargetScore()
    {
        targetCount++;
        Target.text = targetCount.ToString();
    }
}
