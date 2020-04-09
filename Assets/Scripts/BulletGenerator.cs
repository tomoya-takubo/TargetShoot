using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject GameDirector;

    private void Start()
    {

    }

    void Update()
    {
        BulletGenerate(GameDirector.GetComponent<GameDirector_ScoreCountVer>().timeup);

    }

    private void BulletGenerate(bool timeup)
    {
        if (!timeup)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //　弾生成
                GameObject bullet
                    = Instantiate(this.bulletPrefab) as GameObject;
                // Vector3でマウス位置座標を取得する
                Vector3 position = Input.mousePosition;
                // Z軸修正
                position.z = 10f;
                // マウス位置座標をスクリーン座標からワールド座標に変換する
                Vector3 screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
                // ワールド座標に変換されたマウス座標を代入
                bullet.transform.position = screenToWorldPointPosition;
            }
        }
    }
}
