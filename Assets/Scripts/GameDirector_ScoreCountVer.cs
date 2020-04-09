using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector_ScoreCountVer : MonoBehaviour
{
    //GameObject remainingTime;     //Find関数はUnityの中でも屈指の重さを誇る関数のため使用を避けます
    public Text remainingTime;
    public Text Score;
    float time = 60f;
    int scoreCount;

    // Start is called before the first frame update
    void Start()
    {
        //remainingTime = GameObject.Find("RemainingTime"); //Find関数はUnityの中でも屈指の重さを誇る関数のため使用を避けます
    }

    // Update is called once per frame
    void Update()
    {
        //時間更新
        time -= Time.deltaTime;
        if (time < 0) time = 0f;
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
}
