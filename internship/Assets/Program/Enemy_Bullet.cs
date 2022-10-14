using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    private float targetTime = 2.0f;
    private float currentTime = 0.0f;

    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD:internship/Assets/Program/Enemy_Bullet.cs
        currentTime += Time.deltaTime;
        if (targetTime < currentTime)
        {
            currentTime = 0.0f;

            var Bullet = Instantiate(obj,
    new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),
    Quaternion.identity);
            Bullet.name = "Enemy_Bullet";
=======
        // É|Å[ÉYíÜÇÕâΩÇ‡ÇµÇ»Ç¢
        if (Mathf.Approximately(Time.timeScale, 0f))
            return;

        currentTime = Time.deltaTime;
        if (shootTime > currentTime)
        {
            currentTime = 0.0f;

            Instantiate(obj,
            new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),
            Quaternion.identity);

>>>>>>> f927fb9698ea03e27e1c60d9d2b61da16eebe6ae:internship/Assets/‰ªÆÁ¥†Êùê/Enemy_Bullet.cs
        }
    }
}
