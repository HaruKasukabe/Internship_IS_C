using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseUI;

    // Start is called before the first frame update
    void Start()
    {
        pauseUI.SetActive(!pauseUI.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        // 'P'キーでポーズ画面切替
        if (Input.GetKeyDown(KeyCode.P))
        {
            // ポーズUIのアクティブ、非アクティブを切り替え
            pauseUI.SetActive(!pauseUI.activeSelf);
        }

        // ポーズUIが表示されてる時は停止
        if (pauseUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        // ポーズUIが表示されてなければ通常通り進行
        else
        {
            Time.timeScale = 1f;
        }
    }
}
