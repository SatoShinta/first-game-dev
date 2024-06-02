using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitCounter : MonoBehaviour
{
    [SerializeField, Header("�e������������")] private int counter = 0;
    [SerializeField, Header("�����W��")] private float growthFactor = 0.1f;
    [SerializeField, Header("�ړ����x")] private float moveSpeed = 1f;

    private float elapsedTime = 0f;

    private void Update()
    {
        //�X�|�[�����Ă���̌o�ߎ��Ԃ��X�V
        elapsedTime += Time.deltaTime;

        //3�b�o�߂����獶�Ɉړ�
        if (elapsedTime >= 3f)
        {
            MoveLeft();
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

            //object�̃T�C�Y�𑝉�
            Vector3 scale = transform.localScale;//���݂̃X�P�[�����擾
            scale += Vector3.one * growthFactor;//�T�C�Y�𑝉�
            transform.localScale = scale;//�V�����T�C�Y��ݒ�
        }

        //�����Acounter���E���̐��l�𒴂�����
        if (counter >= 10)
        {
            //����script���A�^�b�`���Ă���I�u�W�F�N�g�͏�����
            Destroy(this.gameObject);
        }

        //HP�^�O��������object�ɓ���������
        if (collision.gameObject.tag == "HP")
        {
            //���̃I�u�W�F�N�g��j�󂷂�
            Destroy(this.gameObject);
        }

    }

    //���Ɉړ����郁�\�b�h
    private void MoveLeft()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }
}
