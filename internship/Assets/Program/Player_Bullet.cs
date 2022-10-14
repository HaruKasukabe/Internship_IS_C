using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    // �v���C���[�ړ��̕ϐ�����
    public float MoveSpeed = 0.01f;
    // �v���C���[�̈ړ��͈͐���
    public float MaxPosX = 8.0f;
    public float MinPosX = -8.0f;
    public float MaxPosY = 4.0f;
    public float MinPosY = -4.0f;
    // ��������e��I��
    public GameObject Bulletobj;
    // �e�𐶐�����^�C�}�[
    public int BulletTimer = 60;
<<<<<<< HEAD:internship/Assets/Program/Player_Bullet.cs

    // �v���C���[�̗̑�
    public int HP;

    public GameObject obj;

    // �v���C���[���B
    public GameObject FamiliarObj01;
    public GameObject FamiliarObj02;
    public GameObject FamiliarObj03;
=======
    // �v���C���[�̗̑�
    public int HP;
>>>>>>> f927fb9698ea03e27e1c60d9d2b61da16eebe6ae:internship/Assets/仮素材/Player_Bullet.cs
    // ���݂���g�����̐�
    int NumFamiliar = 0;
    // �ő�g������
    public int Maxfamiliar = 20;
    
    // �_��
    //SpriteRenderer
    SpriteRenderer sp;
    // ����
    public int FlashingCycle = 30;
    // �J�E���g
    private int FlashingCnt = 0;

    // �V�[���J�ڂ��Ă悢��
    public static bool ChangeScene = false;

    private void Awake()
    {
        NumFamiliar = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD:internship/Assets/Program/Player_Bullet.cs

        NumFamiliar = 0;
=======
        NumFamiliar = 0;

        sp = GetComponent<SpriteRenderer>();

        ChangeScene = false;
>>>>>>> f927fb9698ea03e27e1c60d9d2b61da16eebe6ae:internship/Assets/仮素材/Player_Bullet.cs
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

        // �ړ��͈͂ɐ�����������
        var limitPos = transform.position;
        limitPos.x = Mathf.Clamp(limitPos.x, MinPosX, MaxPosX);
        limitPos.y = Mathf.Clamp(limitPos.y, MinPosY, MaxPosY);
        transform.position = limitPos;

        // �e�𐶐�
        if (Input.GetKey(KeyCode.Z) && BulletTimer >= 60)
        {
            BulletTimer = 0;
<<<<<<< HEAD:internship/Assets/Program/Player_Bullet.cs
            Instantiate(obj,
                new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),
                Quaternion.identity);
=======
>>>>>>> f927fb9698ea03e27e1c60d9d2b61da16eebe6ae:internship/Assets/仮素材/Player_Bullet.cs

            Vector2 pos = this.transform.position;
            pos.x += 0.25f;

            Instantiate(Bulletobj,
<<<<<<< HEAD:internship/Assets/Program/Player_Bullet.cs
                new Vector3(pos.x, this.transform.position.y, this.transform.position.z),
                                Quaternion.identity);
=======
                new Vector3(pos.x,this.transform.position.y,this.transform.position.z),
                Quaternion.identity);
>>>>>>> f927fb9698ea03e27e1c60d9d2b61da16eebe6ae:internship/Assets/仮素材/Player_Bullet.cs
        }

        // �e�ɓ���������_��
        if (ChangeScene)
        {
            FlashingCnt++;
            if (FlashingCnt >= FlashingCycle)
            {
                sp.enabled = !sp.enabled;
                FlashingCnt = 0;
            }
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
                ChangeScene = true;
            }
        }
    }
}
