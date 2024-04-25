using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Photon.Pun.MonoBehaviourPun
{
    public GameObject canon;  //　キャノン
    public GameObject tower;  //　砲台
    public Vector3 velocity;              // 移動方向
    public float moveSpeed = 5.0f;        // 移動速度
    public float applySpeed = 0.2f;       // 振向速度
    public KeyCameraController refCamera;  // カメラ参照
   
    void Start()
    {
        refCamera = FindObjectOfType<KeyCameraController>();
    }

    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }
        // 移動の設定
        velocity = velocity.normalized * moveSpeed * Time.deltaTime;

        if (velocity.magnitude > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                  Quaternion.LookRotation(refCamera.hRotation * -velocity),
                                                  applySpeed);
            transform.position += refCamera.hRotation * velocity;
        }

        // 移動WASD入力
        velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            velocity.z += 1;
        if (Input.GetKey(KeyCode.A))
            velocity.x -= 1;
        if (Input.GetKey(KeyCode.S))
            velocity.z -= 1;
        if (Input.GetKey(KeyCode.D))
            velocity.x += 1;

        //砲台とキャノンの角度QWZCでコントロール
        if (Input.GetKey(KeyCode.Q))
            tower.transform.Rotate(0, -20 * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.E))
            tower.transform.Rotate(0, 20 * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.Z))
            canon.transform.Rotate(-20 * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.C))
            canon.transform.Rotate(20 * Time.deltaTime, 0, 0); 
    }
}
