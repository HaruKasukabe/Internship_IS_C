using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PauseCanvas;

    // Start is called before the first frame update
    void Start()
    {
        //pauseUI = GetComponent<GameObject>();
        PauseCanvas.transform.position = new Vector3(0.0f, 100.0f, -1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // 'P'�L�[�Ń|�[�Y��ʐؑ�
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 0f)
            {
                // �|�[�YUI���J�����O�Ɉړ�����
                PauseCanvas.transform.position = new Vector3(0.0f, 100.0f, -1.0f);
                // �i�s
                Time.timeScale = 1f;
            }
            else if (Time.timeScale == 1f)
            {
                // �|�[�YUI���J�������Ɉړ�����
                PauseCanvas.transform.position = new Vector3(0.0f, 0.0f, -1.0f);
                // ��~
                Time.timeScale = 0f;
            }
        }
    }
}
