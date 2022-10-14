using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pause : MonoBehaviour
{
    public TextMeshProUGUI pauseUI;

    // Start is called before the first frame update
    void Start()
    {
        pauseUI.alpha = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // 'P'キーでポーズ画面切替
        if (Input.GetKeyDown(KeyCode.P))
        {
            // ポーズUIのアルファ値を変える
            if (pauseUI.alpha == 0.0f)
            {
                pauseUI.alpha = 1.0f;
            }
            else
            {
                pauseUI.alpha = 0.0f;
            }
        }

        // ポーズUIが表示されてなければ通常通り進行
        if (pauseUI.alpha == 0.0f)
        {
            Time.timeScale = 1.0f;
        }
        // ポーズUIが表示されてる時は停止
        else
        {
            Time.timeScale = 0.0f;
        }
    }
}
