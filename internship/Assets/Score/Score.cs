using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // �C���X�y�N�^�[�Ńe�L�X�g�I�u�W�F�N�g������
    public GameObject ScoreText;

    // �X�R�A�i�[�p
    static int score = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // �I�u�W�F�N�g����Text�R���|�[�l���g���擾
        Text score_text = ScoreText.GetComponent<Text>();

        // �e�L�X�g�̕\�������ւ���
        score_text.text = "Score : " + score;
    }

    // �X�R�A�����Z�������ꏊ�ŌĂяo��
    // Score.AddScore(10);
    // ���� : �P��ő��₵�����l
    public static void AddScore(int num)
    {
        // �����ɓ��ꂽ�l�����Z
        score += num;
    }
}
