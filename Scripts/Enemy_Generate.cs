using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy_Generate : MonoBehaviour
{
    //oŒ»‚³‚¹‚é“G‚ÌƒvƒŒƒnƒu
    [SerializeField, Header("“G")] public GameObject enemy;
    //¶¬ŠÔŠu’²®—p
    [SerializeField, Header("¶¬ŠÔŠu")] float generateInterval = 5f;
    //¶¬I—¹ŠÔ
    [SerializeField, Header("’â~ŠÔ")] float stopTime = 20f;
    [SerializeField, Header("V‚µ‚¢“G‚Ì¶¬ŠÔŠu")] float newEnemyInterval = 15f;
    //•Ï”num‚Ì‰Šú‰»
    float num = 0f;
    //Œo‰ßŠÔ
    float elapsedTime = 0f;
    //“G‚Ì¶¬‚ğ‘±s‚·‚é‚©‚Ç‚¤‚©‚Ìƒtƒ‰ƒO
    bool isGenerate = true;
    float nantyaraTime = 0f;
    


    // Update is called once per frame
    void Update()
    {
        //“G‚Ì¶¬‚ğI—¹‚µ‚Ä‚¢‚½ê‡‚Íˆ—‚ğI—¹‚·‚é
        if (!isGenerate)
            return;

        //num‚Íˆê•b‚²‚Æ‚Éˆê‘‰Á‚·‚é
        num += Time.deltaTime;
        //elapsedTime‚à1•b‚²‚Æ‚É‚P‘‰Á‚·‚é
        elapsedTime += Time.deltaTime;
        nantyaraTime += Time.deltaTime;


        //ˆê’è‚ÌŠÔŠu‚ªŒo‰ß‚µ‚½‚ç“G‚ğ¶¬
        if (num >= generateInterval)
        {
            GenerateEnemies();
            //ƒ^ƒCƒ}[‚ğƒŠƒZƒbƒg
            num = 0f;
        }
           
        //V‚µ‚¢“G‚ğoŒ»‚³‚¹‚éŠÔŠu‚ªŒo‰ß‚µ‚½‚çV‚µ‚¢“G‚ğ¶¬
        if (nantyaraTime >= newEnemyInterval)
        {
            GenerateEnemies2();
            nantyaraTime = 0f;
        }

        if (elapsedTime >= stopTime)
        {
            isGenerate = false;
            Debug.Log("“G‚Ì¶¬‚ğ’â~‚µ‚Ü‚µ‚½");
        }
       
    }


    void GenerateEnemies()
    {
        //“Á’è‚ÌÀ•W‚É“G‚ğ”z’u‚·‚é
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
