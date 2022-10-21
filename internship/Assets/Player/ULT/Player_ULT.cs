using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_ULT : MonoBehaviour
{
    private RectTransform obj;
    public GameObject Ultimate;
    public GameObject UltLast;
    public TextMeshProUGUI readyUI;

    // �K�E�Z�܂ł̃J�E���g
    static float ult_cnt = 0.0f;
    // �K�E�Z�J�E���g�̍ő�l
    public float ult_MaxCnt = 30.0f;
    // �K�E�Z���g������
    private bool play;
    // �ėp
    private float tmp;

    // �K�E�Z�J�n�ʒu
    private Vector2 ultPos;
    // �K�E�Z�������Ă���̃J�E���g
    private int CreateTimer;
    // ������ځH
    private int BombNum;

    // Start is called before the first frame update
    void Start()
    {
        obj = GetComponent<RectTransform>();
        readyUI.alpha = 0.0f;

        ult_cnt = 0.0f;
        play = false;
        tmp = ult_cnt;

        CreateTimer = 120;
    }

    // Update is called once per frame
    void Update()
    {
        if (ult_MaxCnt <= ult_cnt)
        {
            readyUI.alpha = 1.0f;
        }
        else
        {
            readyUI.alpha = 0.0f;
        }


        if (!play)
        {
            // tmp�����̃J�E���g�܂ŏ������l�𑝂₷
            if (ult_cnt >= tmp)
            {
                tmp += 0.05f;
            }

            // �J�E���g���ő�l�Ŏ~�܂�悤�ɂ���
            if (ult_MaxCnt < tmp)
            {
                ult_cnt = ult_MaxCnt;
                tmp = ult_MaxCnt;
            }
        }
        else
        {
            // �J�E���g��0�ɖ߂�
            ult_cnt = 0.0f;

            // tmp�����̃J�E���g�܂ŏ������l�����炷
            if (ult_cnt <= tmp)
            {
                tmp--;
            }

            // tmp��0�ȉ��ɂȂ�����
            if (tmp <= 0)
            {
                tmp = 0.0f;
                CreateExplosion();
            }
        }

        // �J�E���g�������ς���������
        if (ult_MaxCnt <= ult_cnt)
        {
            // ��~���͉����Ȃ��悤�ɂ���
            if (Mathf.Approximately(Time.timeScale, 1f))
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    Time.timeScale = 0.0f;
                    play = true;
                    ultPos = new Vector2(-7.5f, 4.5f);
                    CreateTimer = 120;
                    BombNum = 0;
                }
            }
        }

        // �I�u�W�F�N�g�̑傫���𔽉f����
        obj.sizeDelta = new Vector2(tmp * (450 / ult_MaxCnt), obj.sizeDelta.y);
    }

    // �K�E�Z�J�E���g�����Z�������ꏊ�ŌĂяo��
    public static void AddUltCnt()
    {
        // �l�����Z
        ult_cnt++;
    }

    // �K�E�Z�̓���
    private void CreateExplosion()
    {
        if (BombNum < 6)
        {
            CreateTimer++;
            if (CreateTimer >= 120)
            {
                for (int i = 0; i < 4; i++)
                {
                    Instantiate(Ultimate, new Vector3(ultPos.x, ultPos.y, 0.0f), Quaternion.identity);
                    ultPos.y -= 3.0f;
                }
                ultPos.x += 3.0f;
                ultPos.y = 4.5f;
                BombNum++;
                CreateTimer = 0;
            }
        }
        else
        {
            play = false;
            Instantiate(UltLast, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        }
    }
}
