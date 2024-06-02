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

    private bool canMove = true;//�v���C���[�������邩���݂𐧌䂷��t���O
    private Renderer playerRenderer;//�v���C���[��Renderer�R���|�[�l���g

    //������
    private void Start()
    {
        //Renderer�R���|�[�l���g���擾
        playerRenderer = GetComponent<Renderer>();
    }


    // Update is called once per frame
    void Update()
    {
        if (canMove)
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
        }
        else
        {
            playerRenderer.enabled = !playerRenderer.enabled;
        }
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

    //�v���C���[���G�ɓ����������̏���
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy") || other.CompareTag("enemy3"))
        {
            StartCoroutine(DisableMovementForSeconds(1f));
        }
    }

    //��莞�ԓ����Ȃ�����R���[�`��
    private System.Collections.IEnumerator DisableMovementForSeconds(float seconds)
    {
        canMove = false;
        float timer = 0f;
        while (timer < seconds)
        {
            playerRenderer.enabled = !playerRenderer.enabled;
            yield return new WaitForSeconds(0.1f);//0.1�b���Ƃɓ_��
            timer += 0.1f;
        }
        playerRenderer.enabled = true;// �_�ŏI����A�\�������Ƃɖ߂�
        canMove = true;
    }



}

