using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitCounter : MonoBehaviour
{
    [SerializeField, Header("�e������������")] private int counter = 0;
    private int rnd;
    private int rnd2;
    private int rnd3;

    public void Update()
    {
        //�����_���Ȑ��l���l������
        int rnd = Random.Range(1, 51);
        int rnd2 = Random.Range(1, 71);
        int rnd3 = Random.Range(1, 101);

    }


    //�ق���2d�R���C�_�[�ƐڐG�����Ƃ���
    public void OnCollisionEnter2D(Collision2D collision)    
    {
        //�����ABullet�^�O���������Q�[���I�u�W�F�N�g������script���A�^�b�`���Ă���Q�[���I�u�W�F�N�g�ɓ���������
        if (collision.gameObject.tag == "Bullet")
        {
            //counter�ɐ��l�𑝂₵�Ă���
            counter++;
        }
        
        //�����Acounter���E���̐��l�𒴂�����
        if(counter >= 10)
        {
            //����script���A�^�b�`���Ă���I�u�W�F�N�g�͏�����
            Destroy(this.gameObject);
        }
    }
}

