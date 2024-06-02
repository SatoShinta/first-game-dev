using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy_Generate : MonoBehaviour
{
    [SerializeField, Header("�G")] public GameObject enemy;
    [SerializeField, Header("�����Ԋu")] float generateInterval = 5f;
    float num = 0f;
    


    // Update is called once per frame
    void Update()
    {
        num += Time.deltaTime;

        //���̊Ԋu���o�߂�����G�𐶐�
        if (num >= generateInterval)
        {
            //����̍��W�ɓG��z�u����
            Instantiate(enemy, new Vector3(1, 1, 1), Quaternion.identity);
            //�^�C�}�[�����Z�b�g
            num = 0f;
        }
    }
}
