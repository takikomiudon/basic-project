using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RandomMatchMaker : MonoBehaviourPunCallbacks
{
    public GameObject PhotonObject;
    public KeyCameraController MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();   
    }

    // Update is called once per frame
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;
        PhotonNetwork.CreateRoom(null, roomOptions);
    }

    // Tunkの発生場所をランダムに生成。
    Vector3 GenerateSpawnPosition()
    {
        float x = Random.Range(0, 200); // 0 から 200 までのランダムな値を生成
        Vector3 position;

        if (x < 55)
        {
            position = new Vector3(x - 33, 5, -13);
        }
        else if (x < 100)
        {
            position = new Vector3(22, 5, x - 68);
        }
        else if (x < 155)
        {
            position = new Vector3(x - 133, 5, 32);
        }
        else // x is between 155 and 200
        {
            position = new Vector3(-33, 5, x - 168);
        }

        return position;
    }


    public override void OnJoinedRoom()
    {
        Vector3 spawnPosition = GenerateSpawnPosition(); // ランダムなスポーン位置を取得

        GameObject player = PhotonNetwork.Instantiate(PhotonObject.name, spawnPosition, Quaternion.identity);
        if (player.GetComponent<PlayerController>().photonView.IsMine)
        {
            MainCamera.player = player.transform;
            Debug.Log(MainCamera.player);
        }
    } 
}
