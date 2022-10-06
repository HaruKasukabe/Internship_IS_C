using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // �e�̈ړ����x
    public float MoveSpeed = 0.01f;

    public Player_Bullet player_bullet;

    public static float Bullet_Power;

    // Start is called before the first frame update
    void Start()
    {
        Bullet_Power = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.name != "Prefab_Seeker")
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("���������̂�Enemy�ł���");
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            player_bullet.CreatePlayer();
        }
    }
}
