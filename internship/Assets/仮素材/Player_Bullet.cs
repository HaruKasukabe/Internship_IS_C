using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    // �v���C���[�ړ��̕ϐ�����
     public float MoveSpeed = 0.001f;
    // ��������e��I��
    public GameObject obj;
    // �e�𐶐�����^�C�}�[
    public int BulletTimer = 60;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �e�����^�C�}�[�X�V
        BulletTimer++;
        // �v���C���[�ړ�
        // ��
        if(Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(0.0f, MoveSpeed, 0.0f);
        }
        // ��
        if(Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(0.0f, -MoveSpeed, 0.0f);
        }
        // ��
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-MoveSpeed, 0.0f, 0.0f);
        }
        // �E
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(MoveSpeed, 0.0f, 0.0f);
        }
        // �e�𐶐�
        if(Input.GetKey(KeyCode.Z) && BulletTimer >= 60)
        {
            BulletTimer = 0;
            Instantiate(obj,
                new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z), 
                Quaternion.identity);
        }
        
    }
    // �v���C���[�𑝐B
    public void CreatePlayer()
    {
        Vector3 pos = this.transform.position;
        pos.y = -0.5f;
        Instantiate(this.gameObject,
            new Vector3(this.transform.position.x, pos.y, this.transform.position.z),
             Quaternion.identity);
    }
}
