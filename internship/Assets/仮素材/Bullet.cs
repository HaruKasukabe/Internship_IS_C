<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // ’e‚ÌˆÚ“®‘¬“x
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
        // ƒ|[ƒY’†‚Í‰½‚à‚µ‚È‚¢
        if (Mathf.Approximately(Time.timeScale, 0f))
            return;

        if (this.gameObject.name != "Prefab_Seeker")
        {
            // ’e‚ðˆÚ“®
            this.transform.Translate(MoveSpeed, 0.0f, 0.0f);
        }

        // ƒJƒƒ‰ŠO‚Éo‚½‚çíœ
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Score.AddScore(10/*enemy.GetEnemyScore()*/);// ƒXƒRƒA‰ÁŽZ
            Destroy(this.gameObject);      // ƒoƒŒƒbƒg‚ðíœ
            Destroy(collision.gameObject); // “G‚ðíœ
            Player_ULT.AddUltCnt();        // •KŽE‹ZƒJƒEƒ“ƒg‰ÁŽZ
        }

    }
}
=======
>>>>>>> 228abb0 (èƒŒæ™¯ã‚¹ã‚¯ãƒ­ãƒ¼ãƒ«å·®ã—æ›¿ãˆ)
