using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Createfamiliar : MonoBehaviour
{
    // �ϐ��錾
    public int CreateFamiliarTime = 0; // �����J�E���g�ϐ�
    public int MaxFamiliarTime = 120; // ���̎��ԂɂȂ�����g�����𐶐�����
    public GameObject FamiliarObject1; // �g��������1
    public GameObject FamiliarObject2; // �g��������2
    public GameObject FamiliarObject3; // �g��������3

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // �|�[�Y���͉������Ȃ�
        if (Mathf.Approximately(Time.timeScale, 0f))
            return;

        // �g�����𐶐�����^�C�}�[���X�V
        CreateFamiliarTime++;
        // �^�C�}�[�ȏ�ɂȂ�����
        if(CreateFamiliarTime >= MaxFamiliarTime)
        {
            // 0�ȏ�3�����̐����������_������
            int i = Random.Range(0, 3);
            // �g�����I�u�W�F�N�g�̔z���錾
            GameObject[] FamiliarObject = { FamiliarObject1, FamiliarObject2, FamiliarObject3 };
            // �G�̈ʒu�������������邽�߂̃����_������
            float j = Random.Range(-3, 3);
            // ��ʉE�Ɏg�����𐶐�
            Instantiate(FamiliarObject[i],
                new Vector3(9.0f, j, 0.0f), Quaternion.identity);
            CreateFamiliarTime = 0;
        }
    }
}
