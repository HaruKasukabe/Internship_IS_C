using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// メインのゲームシーンで使うときは
// Test Sugiura の部分を Game に書き換えてね

public class ChangScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 今のシーンが「タイトル」なら
        if (SceneManager.GetActiveScene().name == "Title")
        {
            // Enterキーで
            if (Input.GetKeyDown(KeyCode.Return))
            {
                // ゲーム シーンに移動
                SceneManager.LoadScene("Test Sugiura");
            }
        }

        // 今のシーンが「ゲーム」なら
        if (SceneManager.GetActiveScene().name == "Test Sugiura")
        {
            // プレイヤーがﾀﾋんだら
            if (Player_Bullet.ChangeScene)
            {
                // 3秒後にシーン遷移
                Invoke("ChengeToResult", 3.0f);
            }

            // デバッグ用
            // Spaceキーで
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // リザルト シーンに移動
                SceneManager.LoadScene("Result");
            }
        }

        // 今のシーンが「リザルト」なら
        if (SceneManager.GetActiveScene().name == "Result")
        {
            // Enterキーで
            if (Input.GetKeyDown(KeyCode.Return))
            {
                // タイトル シーンに移動
                SceneManager.LoadScene("Title");
            }

            // Spaceキーで
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // ゲーム シーンに移動
                SceneManager.LoadScene("Test Sugiura");
            }
        }
    }

    // リザルト画面にシーン遷移
    void ChengeToResult()
    {
        SceneManager.LoadScene("Result");

        Player_Bullet.ChangeScene = false;
    }
}
