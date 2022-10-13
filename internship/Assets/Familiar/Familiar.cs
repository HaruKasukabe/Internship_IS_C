using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Familiar : MonoBehaviour
{
    // �ϐ��錾
    public int BulletTime = 30;             // �e��ł��o���Ԋu
    public GameObject BulletObject;         // �e�I�u�W�F�N�g
    public float CaptiveMoveSpeed = 0.01f; // �߂܂��Ă���Ƃ��̈ړ��X�s�[�h
    bool AliveFlg = false;                 // �f�t�H���g���ƕ߂܂��Ă���
    GameObject Player;                     // �v���C���[�I�u�W�F�N�g
    Vector3 OldPlayerPos;                  // �v���C���[��1�t���[���O�̍��W
    public int MaxFamiliar = 20;           // �J�������g�����̍ő吔
    int time;                              // �v���C���[�������Ă���̌o�ߎ���
    float MoveSpeed = 0.01f;               // �J�����̈ړ����x
    bool Flg = true;                       // �v���C���[�Ɠ����ʒu�ɂ��邩
    ManagerPosFamiliar m_PosFamiliar;      // �g�����̈ʒu���Ǘ�����X�N���v�g�̌Ăяo���p
    Vector2 FixedPosition;                 // �g�����̒�ʒu
    Vector2 CalculationFPos;               // �v�Z��̒�ʒu
    int FamiliarNum = -1;                  // �g�����̌̔ԍ�


    // Start is called before the first frame update
    void Start()
    {
        // �V�[������Player�^�O�̃I�u�W�F�N�g��T����Player�ϐ��ɑ��
        Player = GameObject.FindWithTag("Player");
        m_PosFamiliar = GameObject.FindWithTag("Player").GetComponent<ManagerPosFamiliar>();
        // �J�������g�����̐������Z�b�g
    }

    // Update is called once per frame
    void Update()
    {
        // �|�[�Y���͉������Ȃ�
        if (Mathf.Approximately(Time.timeScale, 0f))
            return;

        // �߂܂��Ă���ꍇ�͈ړ��̂ݍs��
        if (!AliveFlg)
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
            // �v���C���[���������ꍇ1�t���[���O�̈ʒu��ۑ�
            if (OldPlayerPos != Player.transform.position)
            {
                Debug.Log("�v���C���[�������܂���");
                OldPlayerPos = Player.transform.position;
                CalculationFPos.x = Player.transform.position.x + FixedPosition.x;
                CalculationFPos.y = Player.transform.position.y + FixedPosition.y;
            }
            // �����Ă��Ȃ����g����������ʒu�ɂ��Ă���ꍇ�̓^�C�}�[�����Z�b�g
            else if((OldPlayerPos == Player.transform.position) && Flg)
            {
                Debug.Log("���Ԃ����Z�b�g���܂���");
                time = 0;
            }

            // �^�C�}�[����莞�Ԉȏ�ɂȂ�
            if(time >= 60)
            {
                // �g�����̈ʒu���v���C���[���E�ɂ���ꍇ
                if(this.transform.position.x > CalculationFPos.x)
                {
                    this.transform.Translate(-MoveSpeed, 0.0f, 0.0f);
                }
                // �g�����̈ʒu���v���C���[��荶�ɂ���ꍇ
                if (this.transform.position.x < CalculationFPos.x)
                {
                    this.transform.Translate( MoveSpeed, 0.0f, 0.0f);
                }
                // �g�����̈ʒu���v���C���[����ɂ���ꍇ
                if (this.transform.position.y > CalculationFPos.y)
                {
                    this.transform.Translate( 0.0f, -MoveSpeed, 0.0f);
                }
                // �g�����̈ʒu���v���C���[��艺�ɂ���ꍇ
                if (this.transform.position.y < CalculationFPos.y)
                {
                    this.transform.Translate( 0.0f, MoveSpeed, 0.0f);
                }
            }
            if (( this.transform.position.x == CalculationFPos.x) && (this.transform.position.y== CalculationFPos.y))
            {
                Debug.Log("�g�����̌��ݒn"+this.transform.position);
                Debug.Log("�v���C���[�̌��ݒn"+Player.transform.position);
                Debug.Log("�g�����̖ړI�n"+ CalculationFPos);
                Flg = true;
            }
            else
            {
                Flg = false;
            }

            // �^�C�}�[�X�V
            time++;
        }
    }

    // �����Ă邩���肷�邽�߂Ƀt���O��n��
    public bool GetAliveFlg()
    {
        return AliveFlg;
    }

    // �J�������ۂɃt���O�𔽓]������
    public void SetAliveFlg()
    {
        // �J���t���O��true�ɂ���
        AliveFlg = true;
        // �̔ԍ����擾����
        FamiliarNum = m_PosFamiliar.SetUseTrueFlg();
        // �̔ԍ������ʒu���擾����
        FixedPosition = m_PosFamiliar.GetFamiliarPos(FamiliarNum);
        // �o�ߎ��Ԃ�61�ɂ��Ď����I�ɒ�ʒu�Ɉړ�����悤�ɂ���
        time = 61;
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

/*
    �v���C���[�̎΂ߍ���Ɏg������u��(�ړ���

 */ 