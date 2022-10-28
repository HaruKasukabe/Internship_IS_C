using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    //　生成タイマ
    public float targetTime = 2.0f;
    private float currentTime = 0.0f;

    public GameObject obj;
    private Animator anime = null;

    private bool bullet;

    // 体力
    public float HP = 3;

    // 被弾のSE
    public AudioClip HitSE;
    // 死亡のSE
    public AudioClip DieSE;
    AudioSource audioSource;
    // 一旦透明化
    public static bool SetVis;
    private bool Once;
    // 消去
    private bool isAudioEnd;
    private float SoundTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();

        // コンポーネント取得　
        audioSource = GetComponent<AudioSource>();
        isAudioEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ポーズ中は何もしない
        if (Mathf.Approximately(Time.timeScale, 0f))
            return;
        // 敵が死んだので行動停止
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
            // 消滅処理
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
    // 被弾
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
