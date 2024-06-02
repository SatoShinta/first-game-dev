using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Generate3 : MonoBehaviour
{
    //�o��������G�̃v���n�u
    [SerializeField, Header("�G")] public GameObject enemy;
    //�����Ԋu�����p
    [SerializeField, Header("�����Ԋu")] float generateInterval = 5f;
    //�����I������
    [SerializeField, Header("��~����")] float stopTime = 20f;

    //�ϐ�num�̏�����
    float num = 0f;
    //�o�ߎ���
    float elapsedTime = 0f;
    //�G�̐����𑱍s���邩�ǂ����̃t���O
    bool isGenerate = true;

    // Start is called before the first frame update
    void Update()
    {
        //�G�̐������I�����Ă����ꍇ�͏������I������
        if (!isGenerate)
            return;

        //num�͈�b���ƂɈꑝ������
        num += Time.deltaTime;
        //elapsedTime��1�b���ƂɂP��������
        elapsedTime += Time.deltaTime;

        if (num >= generateInterval)
        {
            GenerateEnemies4();
            //�^�C�}�[�����Z�b�g
            num = 0f;
        }

        if (elapsedTime >= stopTime)
        {
            isGenerate = false;
            Debug.Log("�G�̐������~���܂���");
        }
    }
    void GenerateEnemies4()
    {
        //����̍��W�ɓG��z�u����
        Instantiate(enemy, new Vector3(13, 2, 0), Quaternion.identity);
        Instantiate(enemy, new Vector3(13, -2, 1), Quaternion.identity);
    }
}
