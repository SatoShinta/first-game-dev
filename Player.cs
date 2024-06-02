using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField, Header("プレイヤースピード")] int speed = 1;
    [SerializeField, Header("X軸上限")] int xjiku = 1;
    [SerializeField, Header("Y軸上限")] int yjiku = 1;
    [SerializeField, Header("弾の種類")] GameObject bulletPrefab;
    [SerializeField, Header("発射口")] GameObject muzzle;
    [SerializeField, Header("発射間隔")] private float shootTimer = 0f;
    private float timer = 0f;



    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0, 0);
        transform.position += new Vector3(0, Input.GetAxis("Vertical") * Time.deltaTime * speed, 0);

        Vector3 vector3 = transform.position;

        vector3.x = Mathf.Clamp(vector3.x, -xjiku, xjiku);
        vector3.y = Mathf.Clamp(vector3.y, -yjiku, yjiku);

        transform.position = vector3;

        //タイマーを更新し、0.5秒ごとに弾を発射する
        timer += Time.deltaTime;
        if (timer >= shootTimer)
        {
            timer = 0f;
            //ここでshootBulletメソッドを呼び出す
            shootBullet();
        }

        //弾を発射するメソッド
        void shootBullet()
        {
            //スペースキーが押されたとき
            if (Input.GetKey(KeyCode.Space))
            {
                GameObject bullet = Instantiate(bulletPrefab, muzzle.transform.position, Quaternion.identity);
                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                if (bulletRigidbody != null)
                {
                    bulletRigidbody.velocity = Vector3.right * 20f;
                }



            }
        }
        
    }
}
