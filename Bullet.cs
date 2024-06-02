using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField, Header("�e������������")] private float lifeTime = 0f;
    [SerializeField, Header("�ő吶������")] private float max_life_time = 4f;

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
        //�e�̃I�u�W�F�N�g���ړ�������
        this.transform.position += new Vector3(0.02f, 0 , 0);


        //�������Ԃ��X�V���A�ő吶�����Ԃ𒴂�����e��������
        lifeTime += Time.deltaTime;
        if (lifeTime > max_life_time)
        {
            Destroy(this.gameObject);
            return;
        }
        
        
       
    }
}
