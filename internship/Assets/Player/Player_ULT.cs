using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_ULT : MonoBehaviour
{
    private RectTransform obj;
    public GameObject ultimate;
    public TextMeshProUGUI readyUI;

    // �K�E�Z�܂ł̃J�E���g
    static float ult_cnt = 0.0f;
    // �K�E�Z�J�E���g�̍ő�l
    public float ult_MaxCnt = 30.0f;
    // �K�E�Z���g������
    private bool play;
    // �ėp
    private float tmp;

    // Start is called before the first frame update
    void Start()
    {
        obj = GetComponent<RectTransform>();

        readyUI.alpha = 0.0f;

        ult_cnt = 0.0f;
        play = false;
        tmp = ult_cnt;
    }

    // Update is called once per frame
    void Update()
    {
        // �|�[�Y���͉������Ȃ�
        if (Mathf.Approximately(Time.timeScale, 0f))
            return;


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
            if(tmp <= 0)
            {
                tmp = 0.0f;
                play = false;
            }
        }

        // �J�E���g�������ς���������
        if(ult_MaxCnt <= ult_cnt)
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                Instantiate(ultimate, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
                play = true;
            }
        }

        // �I�u�W�F�N�g�̑傫���𔽉f����
        obj.sizeDelta = new Vector2(tmp * 15.0f, 70.0f);
    }

    // �K�E�Z�J�E���g�����Z�������ꏊ�ŌĂяo��
    // Player_ULT.AddUltCnt();
    public static void AddUltCnt()
    {
        // �l�����Z
        ult_cnt += 10.0f;
    }
}
