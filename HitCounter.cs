using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitCounter : MonoBehaviour
{
    [SerializeField, Header("弾が当たった回数")] private int counter = 0;



    //ほかの2dコライダーと接触したときに
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //もし、Bulletタグを持ったゲームオブジェクトがこのscriptをアタッチしているゲームオブジェクトに当たったら
        if (collision.gameObject.tag == "Bullet")
        {
            //counterに数値を増やしていく
            counter++;
        }

        //もし、counterが右側の数値を超えたら
        if (counter >= 10)
        {
            //このscriptをアタッチしているオブジェクトは消える
            Destroy(this.gameObject);
        }
    }
}
