using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Familiar : MonoBehaviour
{
    // 弾を打ち出す間隔
    public int BulletTime = 30;
    public GameObject BulletObject;
    public GameObject PlayerObject;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BulletTime++; // 弾発射カウントをプラス
        // 一定時間以上になったら弾を発射
        if(BulletTime >=30) 
        {
            BulletTime = 0; //カウントを0に
            // 弾オブジェクト生成
            Instantiate(BulletObject,
            new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),
             Quaternion.identity);
        }
        // プレイヤーに追従
        //Vector3 pos = PlayerObject.transform.position;
        //pos.y =- 0.25f;
        //Debug.Log(pos);
        //this.transform.position = new Vector3(PlayerObject.transform.position.x, pos.y, PlayerObject.transform.position.z);
        this.transform.position = PlayerObject.transform.position;
        Debug.Log(PlayerObject.transform.position);
    }
    

}
