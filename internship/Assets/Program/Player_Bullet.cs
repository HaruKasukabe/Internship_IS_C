using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    // ƒvƒŒƒCƒ„[ˆÚ“®‚Ì•Ï”¶¬
    public float MoveSpeed = 0.01f;
    // ƒvƒŒƒCƒ„[‚ÌˆÚ“®”ÍˆÍ§ŒÀ
    public float MaxPosX = 8.0f;
    public float MinPosX = -8.0f;
    public float MaxPosY = 4.0f;
    public float MinPosY = -4.0f;
    // ¶¬‚·‚é’e‚ğ‘I‘ğ
    public GameObject Bulletobj;
    // ’e‚ğ¶¬‚·‚éƒ^ƒCƒ}[
    public int BulletTimer = 60;
<<<<<<< HEAD:internship/Assets/Program/Player_Bullet.cs

    // ƒvƒŒƒCƒ„[‚Ì‘Ì—Í
    public int HP;

    public GameObject obj;

    // ƒvƒŒƒCƒ„[‘B
    public GameObject FamiliarObj01;
    public GameObject FamiliarObj02;
    public GameObject FamiliarObj03;
=======
    // ƒvƒŒƒCƒ„[‚Ì‘Ì—Í
    public int HP;
>>>>>>> f927fb9698ea03e27e1c60d9d2b61da16eebe6ae:internship/Assets/ä»®ç´ æ/Player_Bullet.cs
    // Œ»İ‚¢‚ég‚¢–‚‚Ì”
    int NumFamiliar = 0;
    // Å‘åg‚¢–‚”
    public int Maxfamiliar = 20;
    
    // “_–Å
    //SpriteRenderer
    SpriteRenderer sp;
    // üŠú
    public int FlashingCycle = 30;
    // ƒJƒEƒ“ƒg
    private int FlashingCnt = 0;

    // ƒV[ƒ“‘JˆÚ‚µ‚Ä‚æ‚¢‚©
    public static bool ChangeScene = false;

    private void Awake()
    {
        NumFamiliar = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD:internship/Assets/Program/Player_Bullet.cs

        NumFamiliar = 0;
=======
        NumFamiliar = 0;

        sp = GetComponent<SpriteRenderer>();

        ChangeScene = false;
>>>>>>> f927fb9698ea03e27e1c60d9d2b61da16eebe6ae:internship/Assets/ä»®ç´ æ/Player_Bullet.cs
    }

    // Update is called once per frame
    void Update()
    {
        // ƒ|[ƒY’†‚Í‰½‚à‚µ‚È‚¢
        if (Mathf.Approximately(Time.timeScale, 0f))
            return;

        // ’e¶¬ƒ^ƒCƒ}[XV
        BulletTimer++;
        // ƒvƒŒƒCƒ„[ˆÚ“®
        // ã
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(0.0f, MoveSpeed, 0.0f);
        }
        // ‰º
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(0.0f, -MoveSpeed, 0.0f);
        }
        // ¶
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-MoveSpeed, 0.0f, 0.0f);
        }
        // ‰E
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(MoveSpeed, 0.0f, 0.0f);
        }

        // ˆÚ“®”ÍˆÍ‚É§ŒÀ‚ğ‚©‚¯‚é
        var limitPos = transform.position;
        limitPos.x = Mathf.Clamp(limitPos.x, MinPosX, MaxPosX);
        limitPos.y = Mathf.Clamp(limitPos.y, MinPosY, MaxPosY);
        transform.position = limitPos;

        // ’e‚ğ¶¬
        if (Input.GetKey(KeyCode.Z) && BulletTimer >= 60)
        {
            BulletTimer = 0;
<<<<<<< HEAD:internship/Assets/Program/Player_Bullet.cs
            Instantiate(obj,
                new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),
                Quaternion.identity);
=======
>>>>>>> f927fb9698ea03e27e1c60d9d2b61da16eebe6ae:internship/Assets/ä»®ç´ æ/Player_Bullet.cs

            Vector2 pos = this.transform.position;
            pos.x += 0.25f;

            Instantiate(Bulletobj,
<<<<<<< HEAD:internship/Assets/Program/Player_Bullet.cs
                new Vector3(pos.x, this.transform.position.y, this.transform.position.z),
                                Quaternion.identity);
=======
                new Vector3(pos.x,this.transform.position.y,this.transform.position.z),
                Quaternion.identity);
>>>>>>> f927fb9698ea03e27e1c60d9d2b61da16eebe6ae:internship/Assets/ä»®ç´ æ/Player_Bullet.cs
        }

        // ’e‚É“–‚½‚Á‚½‚ç“_–Å
        if (ChangeScene)
        {
            FlashingCnt++;
            if (FlashingCnt >= FlashingCycle)
            {
                sp.enabled = !sp.enabled;
                FlashingCnt = 0;
            }
        }
    }
  
    // Œ»İ‚Ìg‚¢–‚‚Ì”‚ğæ“¾
    public int GetFamiliarNum()
    {
        Debug.Log("g‚¢–‚‚ğ‘İ‚µ‚Ü‚µ‚½");
        return NumFamiliar;
    }
    // g‚¢–‚‚ğ1•CŒ¸‚ç‚·
    public void SetFamiliarNum()
    {
        Debug.Log("g‚¢–‚‚ªŒ¸‚è‚Ü‚µ‚½");
        NumFamiliar--;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "E_Bullet")
        {
            Destroy(other.gameObject);
            HP -= 1;
            if (HP <= 0)
            {
                ChangeScene = true;
            }
        }
    }
}
