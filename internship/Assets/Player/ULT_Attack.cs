using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ULT_Attack : MonoBehaviour
{
    // 生成されてからのフレームをカウント
    private int cnt;

    // Start is called before the first frame update
    void Start()
    {
        cnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // ポーズ中は何もしない
        if (Mathf.Approximately(Time.timeScale, 0f))
            return;

        cnt++;

        if (cnt >= 60)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("ULT Hit");

        if (cnt >= 30)
        {
            Player_ULT.AddUltCnt();

            if (collision.gameObject.tag == "Enemy")
            {
                Debug.Log("Enemy ULT Hit");
                Destroy(collision.gameObject);
                Score.AddScore(10);
            }

            //if (collision.gameObject.tag == "ene1")
            //{
            //    Debug.Log("当たったのはene1でした");
            //    Destroy(collision.gameObject);
            //    Score.AddScore(10);
            //}
            //if (collision.gameObject.tag == "ene2")
            //{
            //    Debug.Log("当たったのはene2でした");
            //    Destroy(collision.gameObject);
            //    Score.AddScore(100);
            //}
            //if (collision.gameObject.tag == "ene3")
            //{
            //    Debug.Log("当たったのはene3でした");
            //    Destroy(collision.gameObject);
            //    Score.AddScore(1000);
            //}
        }
    }
}
