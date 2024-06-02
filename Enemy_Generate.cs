using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy_Generate : MonoBehaviour
{
    [SerializeField, Header("敵")] public GameObject enemy;
    [SerializeField, Header("生成間隔")] float generateInterval = 5f;
    float num = 0f;
    


    // Update is called once per frame
    void Update()
    {
        num += Time.deltaTime;

        //一定の間隔が経過したら敵を生成
        if (num >= generateInterval)
        {
            //特定の座標に敵を配置する
            Instantiate(enemy, new Vector3(1, 1, 1), Quaternion.identity);
            //タイマーをリセット
            num = 0f;
        }
    }
}
