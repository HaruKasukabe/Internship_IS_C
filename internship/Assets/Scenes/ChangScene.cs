using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ���C���̃Q�[���V�[���Ŏg���Ƃ���
// Test Sugiura �̕����� Game �ɏ��������Ă�

public class ChangScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ���̃V�[�����u�^�C�g���v�Ȃ�
        if (SceneManager.GetActiveScene().name == "Title")
        {
            // Enter�L�[��
            if (Input.GetKeyDown(KeyCode.Return))
            {
                // �Q�[�� �V�[���Ɉړ�
                SceneManager.LoadScene("Test Sugiura");
            }
        }

        // ���̃V�[�����u�Q�[���v�Ȃ�
        if (SceneManager.GetActiveScene().name == "Test Sugiura")
        {
            // �v���C���[���˂񂾂�
            if (Player_Bullet.ChangeScene)
            {
                // 3�b��ɃV�[���J��
                Invoke("ChengeToResult", 3.0f);
            }

            // �f�o�b�O�p
            // Space�L�[��
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // ���U���g �V�[���Ɉړ�
                SceneManager.LoadScene("Result");
            }
        }

        // ���̃V�[�����u���U���g�v�Ȃ�
        if (SceneManager.GetActiveScene().name == "Result")
        {
            // Enter�L�[��
            if (Input.GetKeyDown(KeyCode.Return))
            {
                // �^�C�g�� �V�[���Ɉړ�
                SceneManager.LoadScene("Title");
            }

            // Space�L�[��
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // �Q�[�� �V�[���Ɉړ�
                SceneManager.LoadScene("Test Sugiura");
            }
        }
    }

    // ���U���g��ʂɃV�[���J��
    void ChengeToResult()
    {
        SceneManager.LoadScene("Result");

        Player_Bullet.ChangeScene = false;
    }
}
