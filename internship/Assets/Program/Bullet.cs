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

    // ���ŃG�t�F�N�g
    public GameObject DeathEffect;

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
            
            Destroy(this.gameObject);      // �o���b�g���폜
            Destroy(collision.gameObject); // �G���폜
            Score.AddScore(enemy.GetEnemyScore());// �X�R�A���Z
            Player_ULT.AddUltCnt();

            Instantiate(DeathEffect,
                    new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),
                    Quaternion.identity);
        }
    }
}
