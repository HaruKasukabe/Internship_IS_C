<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // eฬฺฎฌx
    public float MoveSpeed = 0.01f;
    Enemy enemy;
    Player_Bullet player_bullet;
    Familiar familiar;
   

    public static float Bullet_Power;

    // Start is called before the first frame update
    void Start()
    {
        Bullet_Power = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // |[Yอฝเตศข
        if (Mathf.Approximately(Time.timeScale, 0f))
            return;

        if (this.gameObject.name != "Prefab_Seeker")
        {
            // e๐ฺฎ
            this.transform.Translate(MoveSpeed, 0.0f, 0.0f);
        }

        // JOษoฝ็ํ
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Score.AddScore(10/*enemy.GetEnemyScore()*/);// XRAมZ
            Destroy(this.gameObject);      // obg๐ํ
            Destroy(collision.gameObject); // G๐ํ
            Player_ULT.AddUltCnt();        // KEZJEgมZ
        }

    }
}
=======
>>>>>>> 228abb0 (่ๆฏในใฏใญใผใซๅทฎใๆฟใ)
