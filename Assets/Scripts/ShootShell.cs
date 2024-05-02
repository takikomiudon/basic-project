using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

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
            GameObject shell = PhotonNetwork.Instantiate("Red Ball", transform.position, Quaternion.identity) as GameObject;

            //弾に発射の力を加えます
            Rigidbody shellRigidbody = shell.GetComponent<Rigidbody>();
            shellRigidbody.AddForce(transform.forward * shotSpeed);

            //remainShootを減らす
            remainShoot = remainShoot - 1;
            shell.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);

            //弾を任意の秒数で消します。
            StartCoroutine(DestroyShellAfterTime(shell, 1.5f));
        }
    }

    IEnumerator DestroyShellAfterTime(GameObject shell, float delay)
    {
        yield return new WaitForSeconds(delay);
        PhotonNetwork.Destroy(shell);
    }
}
