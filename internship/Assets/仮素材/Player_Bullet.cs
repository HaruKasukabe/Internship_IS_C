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
<<<<<<< HEAD
    // �v���C���[�̗̑�
    public int HP;
=======
    // �v���C���[���B
    public GameObject FamiliarObj01;
    public GameObject FamiliarObj02;
    public GameObject FamiliarObj03;
    // ���݂���g�����̐�
    int NumFamiliar = 0;
    // �ő�g������
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
    // �v���C���[�𑝐B
    public void CreatePlayer()
    {
        //Debug.Log("���ݎg������"+NumFamiliar+"�ł�");
        // 20�̖����Ȃ�
        if (NumFamiliar < Maxfamiliar)
        {
            //Debug.Log("�g������" + Maxfamiliar + "�ȉ��ł�");
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
            //Debug.Log("�g�����𐶐����܂���");
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
