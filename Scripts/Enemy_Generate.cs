using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy_Generate : MonoBehaviour
{
    //�o��������G�̃v���n�u
    [SerializeField, Header("�G")] public GameObject enemy;
    //�����Ԋu�����p
    [SerializeField, Header("�����Ԋu")] float generateInterval = 5f;
    //�����I������
    [SerializeField, Header("��~����")] float stopTime = 20f;
    [SerializeField, Header("�V�����G�̐����Ԋu")] float newEnemyInterval = 15f;
    //�ϐ�num�̏�����
    float num = 0f;
    //�o�ߎ���
    float elapsedTime = 0f;
    //�G�̐����𑱍s���邩�ǂ����̃t���O
    bool isGenerate = true;
    float nantyaraTime = 0f;
    


    // Update is called once per frame
    void Update()
    {
        //�G�̐������I�����Ă����ꍇ�͏������I������
        if (!isGenerate)
            return;

        //num�͈�b���ƂɈꑝ������
        num += Time.deltaTime;
        //elapsedTime��1�b���ƂɂP��������
        elapsedTime += Time.deltaTime;
        nantyaraTime += Time.deltaTime;


        //���̊Ԋu���o�߂�����G�𐶐�
        if (num >= generateInterval)
        {
            GenerateEnemies();
            //�^�C�}�[�����Z�b�g
            num = 0f;
        }
           
        //�V�����G���o��������Ԋu���o�߂�����V�����G�𐶐�
        if (nantyaraTime >= newEnemyInterval)
        {
            GenerateEnemies2();
            nantyaraTime = 0f;
        }

        if (elapsedTime >= stopTime)
        {
            isGenerate = false;
            Debug.Log("�G�̐������~���܂���");
        }
       
    }


    void GenerateEnemies()
    {
        //����̍��W�ɓG��z�u����
        Instantiate(enemy, new Vector3(4, 3, 3), Quaternion.identity);
        Instantiate(enemy, new Vector3(5, 0, 2), Quaternion.identity);
        Instantiate(enemy, new Vector3(4, -3, 1), Quaternion.identity);
    }

    void GenerateEnemies2()
    {
        Instantiate(enemy, new Vector3(7, 3, 3), Quaternion.identity);
        Instantiate(enemy, new Vector3(7, -3, 1), Quaternion.identity);
    }
}
