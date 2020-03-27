using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class targetBehavor : MonoBehaviour
{
    private float cnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0f, 0.6f, 0.6f);
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.localScale.x <= 0.6)
        {
            transform.localScale = new Vector3(cnt, 0.6f, 0.6f);
        }
        cnt += 0.1f;

    }
}
