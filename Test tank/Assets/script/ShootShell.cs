using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootShell : MonoBehaviour
{
    //弾のプレファブの指定
    public GameObject shellPrefab;
    //弾の速さを指定
    public float shotSpeed;

    //弾の発射位置
    public GameObject canon;


    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //弾を発生させます
            GameObject shell = Instantiate(shellPrefab, canon.transform.position, Quaternion.identity) as GameObject;

            //弾に発射の力を加えます
            Rigidbody shellRigidbody = shell.GetComponent<Rigidbody>();
            shellRigidbody.AddForce(canon.transform.forward * shotSpeed);

            //弾を任意の秒数で消します。
            Destroy(shell, 5.0f);
        }
    }
}