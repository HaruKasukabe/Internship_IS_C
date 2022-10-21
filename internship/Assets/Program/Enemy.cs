using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 敵の移動速度
    public float MoveSpeed = 0.01f;
    // このエネミーのスコア
    public int NumScore = 100;
    // 仮で敵のスコアをランダムで生成
    int[] TestNumScore = { 10, 100, 1000 };

    // 被弾のSE
    public AudioClip HitSE;
    // 死亡のSE
    public AudioClip DieSE;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // コンポーネント取得　
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // ポーズ中は何もしない
        if (Mathf.Approximately(Time.timeScale, 0f))
            return;

        // 敵を等速で移動
        this.transform.Translate(-MoveSpeed, 0.0f, 0.0f);

        // カメラ外に出たら削除
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }

    }
    // プレイヤーと当たったら
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
        Debug.Log("当たりました");
    }

    // 敵を倒したときのこの敵のスコアを教える
    public int GetEnemyScore()
    {
        //現在は仮置きの為、スコア引数を渡さない
        //return NumScore;
        // 仮処置
        int i = Random.Range(0, 3);
        Debug.Log(TestNumScore[i]);
        return TestNumScore[i];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);      // 敵を削除
            Destroy(collision.gameObject); // 弾を削除
        }
    }

}
