using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCounter3 : MonoBehaviour
{
    [SerializeField, Header("’e‚ª“–‚½‚Á‚½‰ñ”")] private int counter = 0;
    [SerializeField, Header("‘‰ÁŒW”")] private float growthFacter = 0.05f;
    [SerializeField, Header("ˆÚ“®‘¬“x")] private float moveSpead = 1f;
    private float elapsedTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        elapsedTimer += Time.deltaTime;
        if (elapsedTimer >= 3f)
        {
            Moveleft();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            counter++;
            Vector3 scale = transform.localScale;
            scale += Vector3.one * growthFacter;
            transform.localScale = scale;
        }

        if (counter >= 60 || collision.gameObject.tag == "HP")
        {
            Destroy(gameObject);
        }
    }

    private void Moveleft()
    {
        transform.Translate(Vector3.left * moveSpead * Time.deltaTime);
    }
}
