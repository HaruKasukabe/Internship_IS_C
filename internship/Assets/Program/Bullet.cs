using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // �e�̈ړ����x
    public float MoveSpeed = 0.01f;
    public Enemy enemy;
    public Player_Bullet player_bullet;

    // 3Way�e�̐ݒ�
    // �p�x
    private float Angle_3Way;
    // �p�x�̊Ԋu
    private float DevideAngle_3Way = 25.0f;
    // �ړ��x�N�g��
    Vector3[] vec_3Way = new Vector3[3];
    // �g�U�e���ǂ����̔���
    string target_3Way = "3Way";

    // 5Way�e�̐ݒ�
    // �p�x
    private float Angle_5Way;
    // �p�x�̊Ԋu
    private float DevideAngle_5Way = 36.0f;
    // �ړ��x�N�g��
    Vector3[] vec_5Way = new Vector3[5];
    // �g�U�e���ǂ����̔���
    string target_5Way = "5Way";


    public static float Bullet_Power;

    // Start is called before the first frame update
    void Start()
    {
        float WaySpeedT = -MoveSpeed * 1000;
        if (this.gameObject.name.Contains(target_3Way))
        {
            Angle_3Way = 25.0f;
            Bullet_Power = 1.0f;


            // �p�x�����W�A���ɕϊ�
            for (int i = 0; i < Bullet_3Way.makesum; i++)
            {
                float rad = Angle_3Way * Mathf.Deg2Rad;

                // ���W�A������i�s������ݒ�
                Vector3 direction = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0);
                // �����ɑ��x���|�����킹�Ĉړ��x�N�g�������߂�
                vec_3Way[i] = direction * (WaySpeedT * Time.deltaTime);
                Angle_3Way -= DevideAngle_3Way;
            }
        }
        WaySpeedT = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //vec_3Way[0] = new Vector3(-0.02f, 0.01f, 0);
        //vec_3Way[1] = new Vector3(-0.02f, 0.00f, 0);
        //vec_3Way[2] = new Vector3(-0.02f,-0.01f, 0);

        if (this.gameObject.name == "Enemy_Bullet")
        {
            // �e���ړ�
            this.transform.Translate(MoveSpeed, 0.0f, 0.0f);
        }

        if (this.gameObject.name.Contains(target_3Way))
        {
            for (int i = 0; i < Bullet_3Way.makesum; i++)
            {
                string Sum = i.ToString();
                if (this.gameObject.name.Contains(Sum))
                {
                    transform.position += vec_3Way[i];
                    Debug.Log(vec_3Way[i]);
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

            Score.AddScore(enemy.GetEnemyScore());// �X�R�A���Z
            Destroy(this.gameObject);      // �o���b�g���폜
            Destroy(collision.gameObject); // �G���폜
        }
    }
}
