using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Generate3 : MonoBehaviour
{
    //oŒ»‚³‚¹‚é“G‚ÌƒvƒŒƒnƒu
    [SerializeField, Header("“G")] public GameObject enemy;
    //¶¬ŠÔŠu’²®—p
    [SerializeField, Header("¶¬ŠÔŠu")] float generateInterval = 5f;
    //¶¬I—¹ŠÔ
    [SerializeField, Header("’â~ŠÔ")] float stopTime = 20f;

    //•Ï”num‚Ì‰Šú‰»
    float num = 0f;
    //Œo‰ßŠÔ
    float elapsedTime = 0f;
    //“G‚Ì¶¬‚ğ‘±s‚·‚é‚©‚Ç‚¤‚©‚Ìƒtƒ‰ƒO
    bool isGenerate = true;

    // Start is called before the first frame update
    void Update()
    {
        //“G‚Ì¶¬‚ğI—¹‚µ‚Ä‚¢‚½ê‡‚Íˆ—‚ğI—¹‚·‚é
        if (!isGenerate)
            return;

        //num‚Íˆê•b‚²‚Æ‚Éˆê‘‰Á‚·‚é
        num += Time.deltaTime;
        //elapsedTime‚à1•b‚²‚Æ‚É‚P‘‰Á‚·‚é
        elapsedTime += Time.deltaTime;

        if (num >= generateInterval)
        {
            GenerateEnemies4();
            //ƒ^ƒCƒ}[‚ğƒŠƒZƒbƒg
            num = 0f;
        }

        if (elapsedTime >= stopTime)
        {
            isGenerate = false;
            Debug.Log("“G‚Ì¶¬‚ğ’â~‚µ‚Ü‚µ‚½");
        }
    }
    void GenerateEnemies4()
    {
        //“Á’è‚ÌÀ•W‚É“G‚ğ”z’u‚·‚é
        Instantiate(enemy, new Vector3(13, 2, 0), Quaternion.identity);
        Instantiate(enemy, new Vector3(13, -2, 1), Quaternion.identity);
    }
}
