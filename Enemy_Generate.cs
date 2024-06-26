using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy_Generate : MonoBehaviour
{
    //出現させる敵のプレハブ
    [SerializeField, Header("敵")] public GameObject enemy;
    //生成間隔調整用
    [SerializeField, Header("生成間隔")] float generateInterval = 5f;
    //生成終了時間
    [SerializeField, Header("停止時間")] float stopTime = 20f;
    [SerializeField, Header("新しい敵の生成間隔")] float newEnemyInterval = 15f;
    //変数numの初期化
    float num = 0f;
    //経過時間
    float elapsedTime = 0f;
    //敵の生成を続行するかどうかのフラグ
    bool isGenerate = true;
    float nantyaraTime = 0f;
    


    // Update is called once per frame
    void Update()
    {
        //敵の生成を終了していた場合は処理を終了する
        if (!isGenerate)
            return;

        //numは一秒ごとに一増加する
        num += Time.deltaTime;
        //elapsedTimeも1秒ごとに１増加する
        elapsedTime += Time.deltaTime;
        nantyaraTime += Time.deltaTime;


        //一定の間隔が経過したら敵を生成
        if (num >= generateInterval)
        {
            GenerateEnemies();
            //タイマーをリセット
            num = 0f;
        }
           
        //新しい敵を出現させる間隔が経過したら新しい敵を生成
        if (nantyaraTime >= newEnemyInterval)
        {
            GenerateEnemies2();
            nantyaraTime = 0f;
        }

        if (elapsedTime >= stopTime)
        {
            isGenerate = false;
            Debug.Log("敵の生成を停止しました");
        }
       
    }


    void GenerateEnemies()
    {
        //特定の座標に敵を配置する
        Instantiate(enemy, new Vector3(4, 3, 3), Quaternion.identity);
        Instantiate(enemy, new Vector3(5, 0, 2), Quaternion.identity);
        Instantiate(enemy, new Vector3(4, -3, 1), Quaternion.identity);
    }

    void GenerateEnemies2()
    {
        Instantiate(enemy, new Vector3(7, 3, 3), Quaternion.identity);
        Instantiate(enemy, new Vector3(7, -3, 1), Quaternion.identity);
    }
}
