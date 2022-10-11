using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    private float shootTime = 1.0f;
    private float currentTime = 0.0f;

    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.deltaTime;
        if (shootTime > currentTime)
        {
            currentTime = 0.0f;

            Instantiate(obj,
            new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),
            Quaternion.identity);

        }
    }
}
