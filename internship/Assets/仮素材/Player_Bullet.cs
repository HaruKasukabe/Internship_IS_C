using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    // �v���C���[�ړ��̕ϐ�����
    public float MoveSpeed = 0.01f;
    // ��������e��I��
    public GameObject Bulletobj;
    // �e�𐶐�����^�C�}�[
    public int BulletTimer = 60;
    // �v���C���[�̗̑�
    public int HP;
    // ���݂���g�����̐�
    int NumFamiliar = 0;
    // �ő�g������
    public int Maxfamiliar = 20;

    int Rand = 0;

    private void Awake()
    {
        NumFamiliar = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        NumFamiliar = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // �|�[�Y���͉������Ȃ�
        if (Mathf.Approximately(Time.timeScale, 0f))
            return;

        // �e�����^�C�}�[�X�V
        BulletTimer++;
        // �v���C���[�ړ�
        // ��
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(0.0f, MoveSpeed, 0.0f);
        }
        // ��
        if (Input.GetKey(KeyCode.DownArrow))
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
        if (Input.GetKey(KeyCode.Z) && BulletTimer >= 60)
        {
            BulletTimer = 0;

            Vector2 pos = this.transform.position;
            pos.x += 0.25f;
            Instantiate(Bulletobj,
                new Vector3(pos.x,this.transform.position.y,this.transform.position.z),
                Quaternion.identity);
        }

    }
  
    // ���݂̎g�����̐����擾
    public int GetFamiliarNum()
    {
        Debug.Log("�g������݂��܂���");
        return NumFamiliar;
    }
    // �g������1�C���炷
    public void SetFamiliarNum()
    {
        Debug.Log("�g����������܂���");
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
