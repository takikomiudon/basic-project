using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : Photon.Pun.MonoBehaviourPun
{
    public GameObject canon;  //　キャノン
    public GameObject tower;  //　砲台
    public Vector3 velocity;              // 移動方向
    public float moveSpeed = 5.0f;        // 移動速度
    public float applySpeed = 0.2f;       // 振向速度
    public KeyCameraController refCamera;  // カメラ参照
    public TextMeshProUGUI life;
    private bool isBlinking = false;
    public Renderer renderer_body;
    public Renderer renderer_head;
    public Renderer renderer_cannon;
    public Renderer renderer_tirebl;
    public Renderer renderer_tirebr;
    public Renderer renderer_tirefl;
    public Renderer renderer_tirefr;

    bool if_1 = true;

    void Start()
    {
        refCamera = FindObjectOfType<KeyCameraController>();
    }

    IEnumerator BlinkObject(float duration)
    {
        isBlinking = true;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // オブジェクトの表示/非表示を交互に切り替えることで点滅を実現
            renderer_body.enabled = !renderer_body.enabled;
            renderer_head.enabled = !renderer_head.enabled;
            renderer_cannon.enabled = !renderer_cannon.enabled;
            renderer_tirebl.enabled = !renderer_tirebl.enabled;
            renderer_tirebr.enabled = !renderer_tirebr.enabled;
            renderer_tirefl.enabled = !renderer_tirefl.enabled;
            renderer_tirefr.enabled = !renderer_tirefr.enabled;
            

            // 0.1秒待機
            yield return new WaitForSeconds(0.1f);
            elapsedTime += 0.1f;
        }

        // 点滅が終了した後、オブジェクトの表示を元に戻す
        renderer_body.enabled = true;
        renderer_head.enabled = true;
        renderer_cannon.enabled = true;
        renderer_tirebl.enabled = true;
        renderer_tirebr.enabled = true;
        renderer_tirefl.enabled = true;
        renderer_tirefr.enabled = true;

        isBlinking = false;
    }

    // 当たった時に呼ばれる関数
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("syoutotu");
        if (collision.gameObject.name == "Red Ball(Clone)")
        {
            if (!isBlinking)
            {
                // 名前が "name" のオブジェクトに当たった場合、TextMeshProの数値を1減らす
                int currentValue = int.Parse(life.text);
                life.text = (currentValue - 1).ToString();
                // オブジェクトを点滅させるコルーチンを開始
                StartCoroutine(BlinkObject(2f));
            }

        }
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
