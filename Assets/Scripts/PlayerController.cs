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

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(0, -60 * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(0, 60 * Time.deltaTime, 0);

        Vector3 rotation = transform.eulerAngles;
        rotation.x = 0;
        rotation.z = 0;
        transform.eulerAngles = rotation;

        // 移動WASD入力
        velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            velocity -= transform.forward;
        if (Input.GetKey(KeyCode.S))
            velocity += transform.forward;

        velocity = refCamera.hRotation * velocity;
        velocity.y = 0;

        // 移動の設定
        if (velocity.magnitude > 0)
        {
            velocity = velocity.normalized * moveSpeed * Time.deltaTime;
            transform.position += velocity;
        }

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
