using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nWay_Bullet_Launcher : MonoBehaviour
{
    //　弾オブジェクト
    public GameObject Bullet;
    // ベクトルの向き、拡散角度、一度に発射する弾の数
    public float _Velocity_0, Degree, Angle_Split;
    // 弾が飛んでいく角度
    float _theta;
    float PI = Mathf.PI;
    // 発射間隔
    private float targetTime = 2.0f;
    private float currentTime = 0.0f;


    void Update()
    {
        currentTime += Time.deltaTime;

        if (targetTime < currentTime)
        {
            currentTime = 0.0f;
            for (int i = 0; i <= (Angle_Split - 1); i++)
            {

                //n-way弾の端から端までの角度
                float AngleRange = PI * (Degree / 180);

                //弾インスタンスに渡す角度の計算
                if (Angle_Split > 1) _theta = (AngleRange / (Angle_Split - 1)) * i - 0.5f * AngleRange;
                else _theta = 0;

                //弾インスタンスを取得し、初速と発射角度を与える
                GameObject Bullet_obj = (GameObject)Instantiate(Bullet, transform.position, transform.rotation);
                Bullet_obj.name = "nWay_Bullet";
                Bullet_nWays bullet_cs = Bullet_obj.GetComponent<Bullet_nWays>();
                bullet_cs.theta = _theta;
                bullet_cs.Velocity_0 = -_Velocity_0;
            }
        }
    }
}
