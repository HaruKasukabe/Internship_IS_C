using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Familiar : MonoBehaviour
{
    // �e��ł��o���Ԋu
    public int BulletTime = 30;
    public GameObject BulletObject;
    public GameObject PlayerObject;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BulletTime++; // �e���˃J�E���g���v���X
        // ��莞�Ԉȏ�ɂȂ�����e�𔭎�
        if(BulletTime >=30) 
        {
            BulletTime = 0; //�J�E���g��0��
            // �e�I�u�W�F�N�g����
            Instantiate(BulletObject,
            new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),
             Quaternion.identity);
        }
        // �v���C���[�ɒǏ]
        //Vector3 pos = PlayerObject.transform.position;
        //pos.y =- 0.25f;
        //Debug.Log(pos);
        //this.transform.position = new Vector3(PlayerObject.transform.position.x, pos.y, PlayerObject.transform.position.z);
        this.transform.position = PlayerObject.transform.position;
        Debug.Log(PlayerObject.transform.position);
    }
    

}
