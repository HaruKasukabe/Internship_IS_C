using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker_Bullet : MonoBehaviour
{
    //プレイヤーオブジェクト
    private GameObject player;
    //弾のプレハブオブジェクト
    public GameObject seeker;

    //一秒ごとに弾を発射するためのもの
    private float targetTime = 1.0f;
    private float currentTime = 0;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // ポーズ中は何もしない
        if (Mathf.Approximately(Time.timeScale, 0f))
            return;

        //一秒経つごとに弾を発射する
        currentTime += Time.deltaTime;
        if (targetTime < currentTime)
        {
            currentTime = 0;
            //敵の座標を変数posに保存
            var pos = this.gameObject.transform.position;
            //弾のプレハブを作成
            var t = Instantiate(seeker) as GameObject;
            t.name = "Prefab_Seeker";
            //弾のプレハブの位置を敵の位置にする
            t.transform.position = pos;
            //敵からプレイヤーに向かうベクトルをつくる
            //プレイヤーの位置から敵の位置（弾の位置）を引く
            Vector2 vec = player.transform.position - pos;
            //弾のRigidBody2Dコンポネントのvelocityに先程求めたベクトルを入れて力を加える
            t.GetComponent<Rigidbody2D>().velocity = vec;

            Debug.Log(vec);
        }
    }
}
