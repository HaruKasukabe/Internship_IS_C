using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    //�@�����^�C�}
    public float targetTime = 2.0f;
    private float currentTime = 0.0f;

    public GameObject obj;
    private Animator anime = null;

    private bool bullet;

    // �̗�
    public float HP = 3;

    // ��e��SE
    public AudioClip HitSE;
    // ���S��SE
    public AudioClip DieSE;
    AudioSource audioSource;
    // ��U������
    public static bool SetVis;
    private bool Once;
    // ����
    private bool isAudioEnd;
    private float SoundTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();

        // �R���|�[�l���g�擾�@
        audioSource = GetComponent<AudioSource>();
        isAudioEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        // �|�[�Y���͉������Ȃ�
        if (Mathf.Approximately(Time.timeScale, 0f))
            return;
        // �G�����񂾂̂ōs����~
        if (!SetVis)
        {
            currentTime += Time.deltaTime;
            if (targetTime < currentTime)
            {
                anime.SetBool("attack", true);

                currentTime = 0.0f;
            }

            if (bullet)
            {
                var Bullet = Instantiate(obj,
                                new Vector3(this.transform.position.x - 1.0f, this.transform.position.y + 0.3f, this.transform.position.z),
                                Quaternion.identity);
                Bullet.name = "Enemy_Bullet";

                bullet = false;
            }
        }
        else
        {
            // ���ŏ���
            if (SetVis && !Once)
            {
                this.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -100);
                
                audioSource.PlayOneShot(DieSE);
                Once = true;
            }
            if (!audioSource.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }

    private void AttackFin()
    {
        anime.SetBool("attack", false);
    }

    public void ShotBullet()
    {
        bullet = true;
    }
    // ��e
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            HP = HP - Bullet.Bullet_Power;
            if (HP <= 0)
            {
                SetVis = true;
            }
            else
            {
                audioSource.PlayOneShot(HitSE);
            }
        }
    }

}
