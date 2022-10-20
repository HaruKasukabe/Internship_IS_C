using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pause : MonoBehaviour
{
    public TextMeshProUGUI pauseUI;


    // �����SE
    public AudioClip Des_SE;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        pauseUI.alpha = 0.0f;

        // �R���|�[�l���g�擾�@
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // 'P'�L�[�Ń|�[�Y��ʐؑ�
        if (Input.GetKeyDown(KeyCode.P))
        {
            // audioSource.PlayOneShot(Des_SE);
            // �|�[�YUI�̃A���t�@�l��ς���
            if (pauseUI.alpha == 0.0f)
            {
                pauseUI.alpha = 1.0f;
                Time.timeScale = 0.0f;
            }
            else
            {
                pauseUI.alpha = 0.0f;
                Time.timeScale = 1.0f;
            }
        }
        // �|�[�YUI���\������ĂȂ���Βʏ�ʂ�i�s
        if (pauseUI.alpha == 0.0f)
        {
            Time.timeScale = 1.0f;
        }
        // �|�[�YUI���\������Ă鎞�͒�~
        else
        {
            Time.timeScale = 0.0f;
        }
    }
}
