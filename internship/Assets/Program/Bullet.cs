using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // �e�̈ړ����x
    public float MoveSpeed = 0.01f;
    public Enemy enemy;
    public Player_Bullet player_bullet;

<<<<<<< HEAD
    public static bool ScoreFlag;

    // �e�̈З�
=======
>>>>>>> 0f94a737a22e022ec199545e4716bc7b5f53b5ee
    public static float Bullet_Power;
    // �e���g�����̂��̂��ǂ����𔻒肷�邽�߂̕�����
    private string Familiar_Name = "Familiar_Bullet";

    // �e�̈З�
    public float Player_Power = 1;
    public float Fam_1_Power = 0.1f;
    public float Fam_2_Power = 0.25f;
    public float Fam_3_Power = 0.5f;

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
<<<<<<< HEAD

        if (this.gameObject.name == "Player_Bullet" || gameObject.name.Contains(Familiar_Name))
=======
        
        if (this.gameObject.name == "Player_Bullet" || this.gameObject.name == "Familiar_Bullet")
>>>>>>> 0f94a737a22e022ec199545e4716bc7b5f53b5ee
        {
            // �e���ړ�
            this.transform.Translate(MoveSpeed, 0.0f, 0.0f);
            // �З͐ݒ�
            if(gameObject.name == "Player_Bullet")
            {
                Bullet_Power = Player_Power;
            }
            if(gameObject.name.Contains(Familiar_Name))
            {
                if(gameObject.name.Contains("1"))
                {
                    Bullet_Power = Fam_1_Power;
                }
                if (gameObject.name.Contains("2"))
                {
                    Bullet_Power = Fam_2_Power;
                }
                if (gameObject.name.Contains("3"))
                {
                    Bullet_Power = Fam_3_Power;
                }
            }
        }

        // �J�����O�ɏo����폜
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
<<<<<<< HEAD
            //Score.AddScore(enemy.GetEnemyScore());// �X�R�A���Z
            //Destroy(this.gameObject);      // �o���b�g���폜
            //Destroy(collision.gameObject); // �G���폜
            //Player_ULT.AddUltCnt();
=======
            
            Destroy(this.gameObject);      // �o���b�g���폜
            Destroy(collision.gameObject); // �G���폜
            Score.AddScore(enemy.GetEnemyScore());// �X�R�A���Z
            Player_ULT.AddUltCnt();
>>>>>>> 0f94a737a22e022ec199545e4716bc7b5f53b5ee
        }
    }
}
