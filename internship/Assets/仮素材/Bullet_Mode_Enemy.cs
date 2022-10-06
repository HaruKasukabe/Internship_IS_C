using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Mode_Enemy : MonoBehaviour
{
    // �e�̈ړ����x
    public float MoveSpeed = 0.05f;

    public Player_Bullet player_bullet;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // �e���ړ�
        this.transform.Translate(-MoveSpeed, 0.0f, 0.0f);

        // �J�����O�ɏo����폜
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("������܂���");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("���������̂�Player�ł���");
            Destroy(this.gameObject);
        }
    }
}
