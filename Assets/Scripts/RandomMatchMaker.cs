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

    public override void OnJoinedRoom()
    {
        GameObject player = PhotonNetwork.Instantiate(PhotonObject.name, new Vector3(0, 0, 0), Quaternion.identity);
        if (player.GetComponent<PlayerController>().photonView.IsMine)
        {
            MainCamera.player = player.transform;
            Debug.Log(MainCamera.player);
        }
    } 
}
