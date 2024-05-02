using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootShell : Photon.Pun.MonoBehaviourPun
{
    //弾のプレファブの指定
    public GameObject shellPrefab;
    //弾の速さを指定
    public float shotSpeed;
    public float remainShoot;

    void Start()
    {
        
    }

    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        //remainShootを増やす　最大6
        remainShoot += Time.deltaTime;
        if (remainShoot >= 6)
        {
            remainShoot = 6;
        }

        //弾を打つ
        if (remainShoot > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            //弾を発生させます
            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity) as GameObject;

            //弾に発射の力を加えます
            Rigidbody shellRigidbody = shell.GetComponent<Rigidbody>();
            shellRigidbody.AddForce(transform.forward * shotSpeed);

            //remainShootを減らす
            remainShoot = remainShoot - 1;

            //弾を任意の秒数で消します。
            Destroy(shell, 5.0f);
        }
    }
}
