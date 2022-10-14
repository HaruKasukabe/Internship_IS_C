using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_5Ways : MonoBehaviour
{
    private float targetTime = 2.0f;
    private float currentTime = 0.0f;

    public static int makesum = 5;

    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (targetTime < currentTime)
        {
            currentTime = 0.0f;

            for (int i = 0; i < makesum; i++)
            {
                var Bullet = Instantiate(obj,
        new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),
        Quaternion.identity);
                Bullet.name = "5Way_" + i;
            }
        }
    }
}
