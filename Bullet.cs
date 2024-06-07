using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
  
//ほかのオブジェクトのコライダーに当たったら
    private void OnCollisionEnter2D(Collision2D collision)
    {
    　//もしも”enemy”か”enemy3”のタグを持つobjectに当たったら
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "enemy3")
        {
        //このオブジェクトを破壊する
            Destroy(this.gameObject);
        }
    }
　　//ほかのオブジェクトのトリガーに当たったら
    private void OnTriggerEnter2D(Collider2D other)
    {
    //”Wall”タグを持ったobjectに当たったら
        if (other.CompareTag("Wall"))
        {
        //このオブジェクトを破壊する
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //弾のオブジェクトを移動させる
        this.transform.position += new Vector3(0.02f, 0 , 0);


     
        
       
    }
}
