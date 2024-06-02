using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCounter2 : MonoBehaviour
{
    [SerializeField, Header("�e������������")] private int counter = 0;
    [SerializeField, Header("�����W��")] private float growthFactor = 0.1f;
    [SerializeField, Header("�ړ����x")] private float moveSpeed = 1f;
    //�o�ߎ���
    private float elapsedTime = 0f;


    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 3f)
        {
            Moveleft();
        }
    }


    //�ق���2d�R���C�_�[�ƐڐG�����Ƃ���
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //�����ABullet�^�O���������Q�[���I�u�W�F�N�g������script���A�^�b�`���Ă���Q�[���I�u�W�F�N�g�ɓ���������
        if (collision.gameObject.tag == "Bullet")
        {
            //counter�ɐ��l�𑝂₵�Ă���
            counter++;

            Vector3 scale = transform.localScale;
            scale += Vector3.one * growthFactor;
            transform.localScale = scale;
        }

        //�����Acounter���E���̐��l�𒴂�����
        if (counter >= 20)
        {
            //����script���A�^�b�`���Ă���I�u�W�F�N�g�͏�����
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

