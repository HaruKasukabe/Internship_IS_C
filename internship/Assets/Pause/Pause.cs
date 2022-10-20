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
        // 'P'キーでポーズ画面切替
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 0f)
            {
                // ポーズUIをカメラ外に移動する
                PauseCanvas.transform.position = new Vector3(0.0f, 100.0f, -1.0f);
                // 進行
                Time.timeScale = 1f;
            }
            else if (Time.timeScale == 1f)
            {
                // ポーズUIをカメラ内に移動する
                PauseCanvas.transform.position = new Vector3(0.0f, 0.0f, -1.0f);
                // 停止
                Time.timeScale = 0f;
            }
        }
    }
}
