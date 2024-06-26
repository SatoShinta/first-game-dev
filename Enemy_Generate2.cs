using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Generate2 : MonoBehaviour
{
    //出現させる敵のプレハブ
    [SerializeField, Header("敵")] public GameObject enemy;
    //生成間隔調整用
    [SerializeField, Header("生成間隔")] float generateInterval = 5f;
    //生成終了時間
    [SerializeField, Header("停止時間")] float stopTime = 20f;

    //変数numの初期化
    float num = 0f;
    //経過時間
    float elapsedTime = 0f;
    //敵の生成を続行するかどうかのフラグ
    bool isGenerate = true;

    // Start is called before the first frame update
    void Update()
    {
        //敵の生成を終了していた場合は処理を終了する
        if (!isGenerate)
            return;

        //numは一秒ごとに一増加する
        num += Time.deltaTime;
        //elapsedTimeも1秒ごとに１増加する
        elapsedTime += Time.deltaTime;

        if (num >= generateInterval)
        {
            GenerateEnemies3();
            //タイマーをリセット
            num = 0f;
        }

        if (elapsedTime >= stopTime)
        {
            isGenerate = false;
            Debug.Log("敵の生成を停止しました");
        }
    }
    void GenerateEnemies3()
    {
        //特定の座標に敵を配置する
        Instantiate(enemy, new Vector3(7, 4, 3), Quaternion.identity);
        Instantiate(enemy, new Vector3(6, 0, 2), Quaternion.identity);
        Instantiate(enemy, new Vector3(7, -4, 1), Quaternion.identity);
    }
}



