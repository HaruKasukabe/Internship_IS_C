using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_nWays : MonoBehaviour
{
    public float Velocity_0, theta;

    Rigidbody2D rid2d;
    void Start()
    {
        //Rigidbody取得
        rid2d = GetComponent<Rigidbody2D>();
        //角度を考慮して弾の速度計算
        Vector2 bulletV = rid2d.velocity;
        bulletV.x = Velocity_0 * Mathf.Cos(theta);
        bulletV.y = Velocity_0 * Mathf.Sin(theta);
        rid2d.velocity = bulletV;
    }

    void Update()
    {
        // カメラ外に出たら削除
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // あたったエネミーを削除
            Destroy(this.gameObject);
        }
    }


}
