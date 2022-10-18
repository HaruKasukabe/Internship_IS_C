using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // �e�̈ړ����x
    public float MoveSpeed = 0.01f;
    public Enemy enemy;
    public Player_Bullet player_bullet;


    public static float Bullet_Power;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.name == "Player_Bullet")
        {
            // �e���ړ�
            this.transform.Translate(MoveSpeed, 0.0f, 0.0f);
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

            Score.AddScore(enemy.GetEnemyScore());// �X�R�A���Z
            Destroy(this.gameObject);      // �o���b�g���폜
            Destroy(collision.gameObject); // �G���폜
        }
    }
}
