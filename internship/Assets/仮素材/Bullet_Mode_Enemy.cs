using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet_Mode_Enemy : MonoBehaviour
{
    // �e�̈ړ����x
    public float MoveSpeed = 0.05f;

    Player_Bullet player_bullet;

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // ���������G�l�~�[���폜
            Destroy(this.gameObject);
            SceneManager.LoadScene("Result");
        }
    }
}
