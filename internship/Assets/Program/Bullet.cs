using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // �e�̈ړ����x
    public float MoveSpeed = 0.01f;
    public Enemy enemy;
    public Player_Bullet player_bullet;

    public static bool ScoreFlag;

    public static float Bullet_Power;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // �|�[�Y���͉������Ȃ�
        if (Mathf.Approximately(Time.timeScale, 0f))
            return;

        if (this.gameObject.name == "Player_Bullet" || this.gameObject.name == "Familiar_Bullet")
        {
            // �e���ړ�
            this.transform.Translate(MoveSpeed, 0.0f, 0.0f);
        }

        if (ScoreFlag)
        {
            Score.AddScore(enemy.GetEnemyScore());// �X�R�A���Z
            ScoreFlag = false;
        }


        // �J�����O�ɏo����폜
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
    }
<<<<<<< HEAD

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Score.AddScore(enemy.GetEnemyScore());// �X�R�A���Z
            Destroy(this.gameObject);      // �o���b�g���폜
            Destroy(collision.gameObject); // �G���폜
            Player_ULT.AddUltCnt();
        }
    }
=======
>>>>>>> 59293383f753c0e999b7706b086e342ff0d439c1
}
