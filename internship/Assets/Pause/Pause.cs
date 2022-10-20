using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pause : MonoBehaviour
{
    public TextMeshProUGUI pauseUI;


    // 決定のSE
    public AudioClip Des_SE;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        pauseUI.alpha = 0.0f;

        // コンポーネント取得　
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // 'P'キーでポーズ画面切替
        if (Input.GetKeyDown(KeyCode.P))
        {
            // audioSource.PlayOneShot(Des_SE);
            // ポーズUIのアルファ値を変える
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
