using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // �R���|�[�l���g�i�[�p
    Text score_text;

    // �C���X�y�N�^�[�Ńe�L�X�g�I�u�W�F�N�g������
    public GameObject ScoreTextObj;

    // �X�R�A�i�[�p
    static int score = 0;

    // �V�[���̏��߂ɃX�R�A��'0'�ɖ߂����̃t���O
    public bool ScoreReset = true;

    // Start is called before the first frame update
    void Start()
    {
        // true �Ȃ�V�[���̂͂��߂�'0'�ɖ߂�
        if (ScoreReset)
            score = 0;

        // �I�u�W�F�N�g����Text�R���|�[�l���g���擾
        score_text = ScoreTextObj.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // �e�L�X�g�̕\�������ւ���
        score_text.text = "Score : " + score;
    }

    // �X�R�A�����Z�������ꏊ�ŌĂяo��
    // Score.AddScore(10);
    // ���� : �P��ő��₵�����l
    public static void AddScore(int num)
    {
        // �����ɓ��ꂽ�l�����Z
        Debug.Log("���Z����O");
        score += num;
        Debug.Log("���Z�����");
    }
}
