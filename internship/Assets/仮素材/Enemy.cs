using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // �G�̈ړ����x
    public float MoveSpeed = 0.01f;
    // Player_Bullet���Q�Ƃ��邽��
    Player_Bullet playerbullet;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // �G�𓙑��ňړ�
        this.transform.Translate(-MoveSpeed, 0.0f, 0.0f);

        // �J�����O�ɏo����폜
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }

    }
    // �v���C���[�Ɠ���������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �v���C���[���g�����ɂ��������ꍇ
        if (collision.gameObject.tag == "Familiar" || collision.gameObject.tag == "Player")
        {
            // �g����������ꍇ
            if (playerbullet.GetFamiliarNum() > 0)
            {
                Debug.Log("�g������1�C�ȏア�܂�");
                Destroy(collision.gameObject);
                playerbullet.SetFamiliarNum();
            }
            // �g���������Ȃ��ꍇ
            else
            {
                Debug.Log("�g���������܂���");
                Destroy(collision.gameObject);
            }
        }

    }
}
