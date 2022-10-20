using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ULT_Attack : MonoBehaviour
{
    // ��������Ă���̃t���[�����J�E���g
    private int cnt;
    // �I�u�W�F�N�g���Ŏ��Ɏ��ԓ������Ă����H
    public bool TimeMove = false;

    // Start is called before the first frame update
    void Start()
    {
        cnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cnt++;

        if (cnt >= 370)
        {
            Destroy(this.gameObject);
            if(TimeMove)
                Time.timeScale = 1.0f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (cnt >= 360)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Debug.Log("Enemy ULT Hit");
                Destroy(collision.gameObject);
                Score.AddScore(10);
                Player_ULT.AddUltCnt();
            }

            //if (collision.gameObject.tag == "ene1")
            //{
            //    Debug.Log("���������̂�ene1�ł���");
            //    Destroy(collision.gameObject);
            //    Score.AddScore(10);
            //}
            //if (collision.gameObject.tag == "ene2")
            //{
            //    Debug.Log("���������̂�ene2�ł���");
            //    Destroy(collision.gameObject);
            //    Score.AddScore(100);
            //}
            //if (collision.gameObject.tag == "ene3")
            //{
            //    Debug.Log("���������̂�ene3�ł���");
            //    Destroy(collision.gameObject);
            //    Score.AddScore(1000);
            //}
        }
    }
}
