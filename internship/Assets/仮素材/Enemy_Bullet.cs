using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    float Timer;

    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer = Timer + Time.deltaTime;
        if (Timer >= 1.0f)
        {
            Instantiate(obj,
            new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),
            Quaternion.identity);

            Timer = 0.0f;
        }
    }
}
