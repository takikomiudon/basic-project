using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class KeyCameraController : MonoBehaviourPun
{
    public float turnSpeed = 10.0f;   // 回転速度
    public Transform player;          // 対象プレイヤー
    public float distance = 10.0f;    // 距離
    [System.NonSerialized] public Quaternion vRotation;      // 垂直回転
    [System.NonSerialized] public Quaternion hRotation;      // 水平回転
    public float camx = 30f;  //垂直回転の初期値

    private PhotonView photonView;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (photonView.IsMine)
        {
            vRotation = Quaternion.Euler(camx, 0, 0);         
            hRotation = Quaternion.identity;               
            transform.rotation = hRotation * vRotation;     
            transform.position = player.position - transform.rotation * Vector3.forward * distance;
        }
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(camx, player.eulerAngles.y + 180, 0);
        transform.position = player.position + new Vector3(0, 3, 0) - transform.rotation * Vector3.forward * distance;
   }
}
