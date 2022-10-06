using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    // プレイヤー移動の変数生成
    public float MoveSpeed = 0.01f;
    // 生成する弾を選択
    public GameObject Bulletobj;
    // 弾を生成するタイマー
    public int BulletTimer = 60;
<<<<<<< HEAD
    // プレイヤーの体力
    public int HP;
=======
    // プレイヤー増殖
    public GameObject FamiliarObj01;
    public GameObject FamiliarObj02;
    public GameObject FamiliarObj03;
    // 現在いる使い魔の数
    int NumFamiliar = 0;
    // 最大使い魔数
    public int Maxfamiliar = 20;

    int Rand = 0;

    private void Awake()
    {
        NumFamiliar = 0;
    }
>>>>>>> fc932d55feba288e6d0bdc8b35010a937f195c89

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD

=======
        NumFamiliar = 0;
>>>>>>> fc932d55feba288e6d0bdc8b35010a937f195c89
    }

    // Update is called once per frame
    void Update()
    {
        // 弾生成タイマー更新
        BulletTimer++;
        // プレイヤー移動
        // 上
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(0.0f, MoveSpeed, 0.0f);
        }
        // 下
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(0.0f, -MoveSpeed, 0.0f);
        }
        // 左
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-MoveSpeed, 0.0f, 0.0f);
        }
        // 右
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(MoveSpeed, 0.0f, 0.0f);
        }
        // 弾を生成
        if (Input.GetKey(KeyCode.Z) && BulletTimer >= 60)
        {
            BulletTimer = 0;
<<<<<<< HEAD
            Instantiate(obj,
                new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),
=======
            Vector2 pos = this.transform.position;
            pos.x += 0.25f;
            Instantiate(Bulletobj,
                new Vector3(pos.x,this.transform.position.y,this.transform.position.z), 
>>>>>>> fc932d55feba288e6d0bdc8b35010a937f195c89
                Quaternion.identity);
        }

    }
    // プレイヤーを増殖
    public void CreatePlayer()
    {
        //Debug.Log("現在使い魔は"+NumFamiliar+"です");
        // 20体未満なら
        if (NumFamiliar < Maxfamiliar)
        {
            //Debug.Log("使い魔は" + Maxfamiliar + "以下です");
            Vector3 pos = this.transform.position;
            pos.y = -0.5f;
            Rand = Random.Range(1, 4);
            if (Rand == 1)
            {
                Instantiate(FamiliarObj01, pos, Quaternion.identity);
            }
            if (Rand == 2)
            {
                Instantiate(FamiliarObj02, pos, Quaternion.identity);

            }
            if (Rand == 3)
            {
                Instantiate(FamiliarObj03, pos, Quaternion.identity);
            }
            NumFamiliar++;
            //Debug.Log("使い魔を生成しました");
        }
    }
    // 現在の使い魔の数を取得
    public int GetFamiliarNum()
    {
        Debug.Log("使い魔を貸しました");
        return NumFamiliar;
    }
    // 使い魔を1匹減らす
    public void SetFamiliarNum()
    {
        Debug.Log("使い魔が減りました");
        NumFamiliar--;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "E_Bullet")
        {
            Destroy(other.gameObject);
            HP -= 1;
            if (HP <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
