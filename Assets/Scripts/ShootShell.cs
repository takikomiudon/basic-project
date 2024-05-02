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

    void Start()
    {

    }

    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //弾を発生させます
            GameObject shell = PhotonNetwork.Instantiate("Red Ball", transform.position, Quaternion.identity) as GameObject;

            //弾に発射の力を加えます
            Rigidbody shellRigidbody = shell.GetComponent<Rigidbody>();
            shellRigidbody.AddForce(transform.forward * shotSpeed);

            shell.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);

            //弾を任意の秒数で消します。
            PhotonNetwork.Destroy(shell, 5.0f);
        }
    }
}
