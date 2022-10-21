using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // �G�̈ړ����x
    public float MoveSpeed = 0.01f;
    // ���̃G�l�~�[�̃X�R�A
    public int NumScore = 100;
    // ���œG�̃X�R�A�������_���Ő���
    int[] TestNumScore = { 10, 100, 1000 };

    // ��e��SE
    public AudioClip HitSE;
    // ���S��SE
    public AudioClip DieSE;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // �R���|�[�l���g�擾�@
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // �|�[�Y���͉������Ȃ�
        if (Mathf.Approximately(Time.timeScale, 0f))
            return;

        // �G�𓙑��ňړ�
        this.transform.Translate(-MoveSpeed, 0.0f, 0.0f);

        // �J�����O�ɏo����폜
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }

    }
    // �v���C���[�Ɠ���������
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
        Debug.Log("������܂���");
    }

    // �G��|�����Ƃ��̂��̓G�̃X�R�A��������
    public int GetEnemyScore()
    {
        //���݂͉��u���ׁ̈A�X�R�A������n���Ȃ�
        //return NumScore;
        // �����u
        int i = Random.Range(0, 3);
        Debug.Log(TestNumScore[i]);
        return TestNumScore[i];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);      // �G���폜
            Destroy(collision.gameObject); // �e���폜
        }
    }

}
