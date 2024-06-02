using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField, Header("弾が生きた時間")] private float lifeTime = 0f;
    [SerializeField, Header("最大生存時間")] private float max_life_time = 4f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //弾のオブジェクトを移動させる
        this.transform.position += new Vector3(0.02f, 0 , 0);


        //生存時間を更新し、最大生存時間を超えたら弾が消える
        lifeTime += Time.deltaTime;
        if (lifeTime > max_life_time)
        {
            Destroy(this.gameObject);
            return;
        }
        
        
       
    }
}
