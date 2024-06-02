using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nest : MonoBehaviour
{
    [SerializeField, Header("HP")] int HP = 10;

    //敵がNestにぶつかった際に呼び出される
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //衝突したobjectが"enemy"タグを持っているか確認
        if (collision.gameObject.CompareTag("enemy"))
        {
            //HPを減らす
            HP--;

            //HPが0以下になったら巣を破壊する
            if(HP <= 0)
            {
                DestroyNest();
            }
        }
    }

    //巣を破壊するメソッド
    private void DestroyNest()
    {
        Destroy(gameObject);
        Debug.Log("Nest destroyed");
    }

}
