using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreRanking : MonoBehaviour
{
    static public ScoreRanking instance;

    private int[] Score_Ranking = new int[6];

    // �I�u�W�F�N�g�擾
    public GameObject obj;
    public TextMeshProUGUI First;
    public TextMeshProUGUI Second;
    public TextMeshProUGUI Third;
    public TextMeshProUGUI Fourth;
    public TextMeshProUGUI Fifth;

    // 1�񂾂�
    private bool once;
    // �ėp
    private int tmp;

    // Start is called before the first frame update
    void Start()
    {
        // OnActiveSceneChanged�֐����g�����߂�
        SceneManager.activeSceneChanged += OnActiveSceneChanged;

        once = true;
        tmp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (once)
        {
            Score_Ranking[5] = Score.score;

            // �\�[�g
            Array.Sort(Score_Ranking);
            Array.Reverse(Score_Ranking);

            once = false;
        }

        // �e�L�X�g�ɒl�𔽉f����
        First.SetText("1st : {0000000}", Score_Ranking[0]);
        Second.SetText("2nd : {0000000}", Score_Ranking[1]);
        Third.SetText("3rd : {0000000}", Score_Ranking[2]);
        Fourth.SetText("4th : {0000000}", Score_Ranking[3]);
        Fifth.SetText("5th : {0000000}", Score_Ranking[4]);
    }

    // �V�[�����ς�����u�ԂɌĂяo�����֐�
    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        if (nextScene.name == "Title")
        {
            once = true;
            obj.transform.position = new Vector3(460.0f, 740.0f, 0.0f);
        }
        else
        {
            obj.transform.position = new Vector3(-1000.0f, 740.0f, 0.0f);
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            Debug.Log("ScoreRanking�������܂���");
        }
    }
}
