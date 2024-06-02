using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCounter2 : MonoBehaviour
{
    [SerializeField, Header("弾が当たった回数")] private int counter = 0;
    [SerializeField, Header("増加係数")] private float growthFactor = 0.1f;
    [SerializeField, Header("移動速度")] private float moveSpeed = 1f;
    //経過時間
    private float elapsedTime = 0f;


    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 3f)
        {
            Moveleft();
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

            Vector3 scale = transform.localScale;
            scale += Vector3.one * growthFactor;
            transform.localScale = scale;
        }

        //もし、counterが右側の数値を超えたら
        if (counter >= 20)
        {
            //このscriptをアタッチしているオブジェクトは消える
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "HP")
        {
            Destroy(this.gameObject);
        }
    }

    private void Moveleft()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }
}

