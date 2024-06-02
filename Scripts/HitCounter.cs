using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitCounter : MonoBehaviour
{
    [SerializeField, Header("弾が当たった回数")] private int counter = 0;
    [SerializeField, Header("増加係数")] private float growthFactor = 0.1f;
    [SerializeField, Header("移動速度")] private float moveSpeed = 1f;

    private float elapsedTime = 0f;

    private void Update()
    {
        //スポーンしてからの経過時間を更新
        elapsedTime += Time.deltaTime;

        //3秒経過したら左に移動
        if (elapsedTime >= 3f)
        {
            MoveLeft();
        }
    }



    //ほかの2dコライダーと接触したときに
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //もし、Bulletタグを持ったゲームオブジェクトがこのscriptをアタッチしているゲームオブジェクトに当たったら
        if (collision.gameObject.tag == "Bullet")
        {
            //counterに数値を増やしていく
            counter++;

            //objectのサイズを増加
            Vector3 scale = transform.localScale;//現在のスケールを取得
            scale += Vector3.one * growthFactor;//サイズを増加
            transform.localScale = scale;//新しいサイズを設定
        }

        //もし、counterが右側の数値を超えたら
        if (counter >= 10)
        {
            //このscriptをアタッチしているオブジェクトは消える
            Destroy(this.gameObject);
        }

        //HPタグを持ったobjectに当たったら
        if (collision.gameObject.tag == "HP")
        {
            //このオブジェクトを破壊する
            Destroy(this.gameObject);
        }

    }

    //左に移動するメソッド
    private void MoveLeft()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }
}
