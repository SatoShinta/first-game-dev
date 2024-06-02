using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nest : MonoBehaviour
{
    [SerializeField, Header("HP")] int HP = 10;

    //�G��Nest�ɂԂ������ۂɌĂяo�����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�Փ˂���object��"enemy"�^�O�������Ă��邩�m�F
        if (collision.gameObject.CompareTag("enemy"))
        {
            //HP�����炷
            HP--;

            //HP��0�ȉ��ɂȂ����瑃��j�󂷂�
            if(HP <= 0)
            {
                DestroyNest();
            }
        }
    }

    //����j�󂷂郁�\�b�h
    private void DestroyNest()
    {
        Destroy(gameObject);
        Debug.Log("Nest destroyed");
    }

}
