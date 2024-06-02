using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField, Header("�v���C���[�X�s�[�h")] int speed = 1;
    [SerializeField, Header("X�����")] int xjiku = 1;
    [SerializeField, Header("Y�����")] int yjiku = 1;
    [SerializeField, Header("�e�̎��")] GameObject bulletPrefab;
    [SerializeField, Header("���ˌ�")] GameObject muzzle;
    [SerializeField, Header("���ˊԊu")] private float shootTimer = 0f;
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

        //�^�C�}�[���X�V���A0.5�b���Ƃɒe�𔭎˂���
        timer += Time.deltaTime;
        if (timer >= shootTimer)
        {
            timer = 0f;
            //������shootBullet���\�b�h���Ăяo��
            shootBullet();
        }

        //�e�𔭎˂��郁�\�b�h
        void shootBullet()
        {
            //�X�y�[�X�L�[�������ꂽ�Ƃ�
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
