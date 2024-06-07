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

    private bool canMove = true;//プレイヤーが動けるか銅貨を制御するフラグ
    private Renderer playerRenderer;//プレイヤーのRendererコンポーネント

    //初期化
    private void Start()
    {
        //Rendererコンポーネントを取得
        playerRenderer = GetComponent<Renderer>();
    }


    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * speed, Input.GetAxis("Vertical") * Time.deltaTime * speed, 0);

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
        }
        else
        {
            playerRenderer.enabled = !playerRenderer.enabled;
        }
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

    //プレイヤーが敵に当たった時の処理
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy") || other.CompareTag("enemy3"))
        {
            StartCoroutine(DisableMovementForSeconds(1f));
        }
    }

    //一定時間動けなくするコルーチン
    private System.Collections.IEnumerator DisableMovementForSeconds(float seconds)
    {
        canMove = false;
        float timer = 0f;
        while (timer < seconds)
        {
            playerRenderer.enabled = !playerRenderer.enabled;
            yield return new WaitForSeconds(0.1f);//0.1秒ごとに点滅
            timer += 0.1f;
        }
        playerRenderer.enabled = true;// 点滅終了後、表示をもとに戻す
        canMove = true;
    }



}

