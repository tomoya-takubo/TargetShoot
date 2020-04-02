using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public float count = 0;
    GameObject bulletCountText;
    GameObject remainingTime;
    float time = 60f;

    // Start is called before the first frame update
    void Start()
    {
        bulletCountText = GameObject.Find("TargetCounterText");
        remainingTime = GameObject.Find("RemainingTime");
    }

    // Update is called once per frame
    void Update()
    {
        //時間表示
        time -= Time.deltaTime;
        if(time < 0) time = 0f;
        remainingTime.GetComponent<Text>().text
            = time.ToString("F2");

        //ヒットしたターゲットの数表示
        GetTargetCount();
;    }

    public void TargetHitCount()
    {
        count++;
    }

    public void GetTargetCount()
    {
        bulletCountText.GetComponent<Text>().text
            = "Target × " + count.ToString();
        //Debug.Log(count);
    }
}
