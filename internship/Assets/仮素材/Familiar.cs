using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Familiar : MonoBehaviour
{
    // �ϐ��錾
    public int BulletTime = 30;     // �e��ł��o���Ԋu
    public GameObject BulletObject; // �e�I�u�W�F�N�g
    public float MoveSpeed = 0.01f; // �߂܂��Ă���Ƃ��̈ړ��X�s�[�h
    bool AliveFlg = false;          // �f�t�H���g���ƕ߂܂��Ă���
    GameObject Player;              // �v���C���[�I�u�W�F�N�g
    Vector3 OldPlayerPos;           // �v���C���[��1�t���[���O�̍��W
    int NumFamiliar = 0;            // ���݂̊J�������g�����̐�
    public int MaxFamiliar = 20;    // �J�������g�����̍ő吔


    // Start is called before the first frame update
    void Start()
    {
        // �V�[������Player�^�O�̃I�u�W�F�N�g��T����Player�ϐ��ɑ��
        Player = GameObject.FindWithTag("Player");
        // �J�������g�����̐������Z�b�g
        NumFamiliar = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // �߂܂��Ă���ꍇ�͈ړ��̂ݍs��
        if(!AliveFlg)
        {
            this.transform.Translate(-MoveSpeed, 0.0f, 0.0f);
            // ��ʊO�ɂ�����
            if(!GetComponent<Renderer>().isVisible)
            {
                // ���̃I�u�W�F�N�g�폜
                Destroy(this.gameObject);
            }
        }
        
        // �J������Ă���ꍇ�͈ړ��ƍU�����s��
        if (AliveFlg)
        {
            BulletTime++; // �e���˃J�E���g���v���X
                          // ��莞�Ԉȏ�ɂȂ�����e�𔭎�
            if (BulletTime >= 30 && Input.GetKey(KeyCode.Z))
            {
                BulletTime = 0; //�J�E���g��0��
                                // �e�I�u�W�F�N�g����
                Instantiate(BulletObject,
                new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),
                 Quaternion.identity);
            }
            // �v���C���[�ɒǏ]
            //Vector3 pos = PlayerObject.transform.position;
            //pos.y =- 0.25f;
            //Debug.Log(pos);
            //this.transform.position = new Vector3(PlayerObject.transform.position.x, pos.y, PlayerObject.transform.position.z);
            this.transform.position = Player.transform.position;
        }
    }

    // �����Ă邩���肷�邽�߂Ƀt���O��n��
    public bool GetAliveFlg()
    {
        Debug.Log(AliveFlg + "��Ԃ��܂�");
        return AliveFlg;
    }

    // �J�������ۂɃt���O�𔽓]������
    public void SetAliveFlg()
    {
        AliveFlg = true;
        this.transform.position = Player.transform.position;
    }

    // Bullet�Ƃ̓����蔻��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �e�Ƃ���������
        if (collision.gameObject.tag == "Bullet")
        {
            // ���̎g�����̃t���O��false�Ȃ�
            if (!GetAliveFlg())
            {
                // �t���O�𔽓]&&�ړ�
                SetAliveFlg();
                // �e�I�u�W�F�N�g���폜
                Destroy(collision.gameObject);
            }
        }
    }

}
