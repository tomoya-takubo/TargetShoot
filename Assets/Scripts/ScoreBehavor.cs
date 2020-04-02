using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBehavor : MonoBehaviour
{
    public float waitTime;

    private TextMesh textMesh;
    private float timeCount;
    private bool isSetup;
    // Start is called before the first frame update
    public void Setup(string score)
    {
        textMesh = GetComponent<TextMesh>();
        textMesh.text = score;
        isSetup = true;
    }

    // Update is called once per frame
    void Update()
    {
        //
        if(isSetup == false)
        {
            return;
        }

        //時間更新
        timeCount += Time.deltaTime;
        //アルファ値更新
        textMesh.color = new Color(0, 0, 0, 1 - timeCount / waitTime);  //読み取り専用（？）のためか、アルファ値の単独変更がエラー
        //規定時間経過後消滅
        if (timeCount > waitTime) Destroy(this.gameObject);
    }
}
