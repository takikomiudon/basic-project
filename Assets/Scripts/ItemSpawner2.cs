using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ItemSpawner2 : MonoBehaviourPunCallbacks
{
    public GameObject itemPrefab; // アイテムのプレファブ
    public float spawnInterval =  60f; // アイテムが生成される時間間隔（秒）
    private float timer;
    private GameObject item;

    void Update()
    {
        //if (!PhotonNetwork.IsMasterClient)
        //{
        //    Debug.Log("aaa");
        //    return; // マスタークライアントのみがアイテムを生成する
        //}

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            Debug.Log(" ItemSpawn");
            SpawnItem();
            timer = 0;
        }

    }

    //  アイテムの発生場所をランダムに生成。
    Vector3 GenerateSpawnPosition()
    {
        float x = Random.Range(0, 200); // 0 から 200 までのランダムな値を生成
        Vector3 position;

        if (x < 55)
        {
            position = new Vector3(x - 33, 1, -13);
        }
        else if (x < 100)
        {
            position = new Vector3(22, 1, x - 68);
        }
        else if (x < 155)
        {
            position = new Vector3(x - 133, 1, 32);
        }
        else // x is between 155 and 200
        {
            position = new Vector3(-33, 1, x - 168);
        }

        return position;
    }

    void SpawnItem()
    {
        Vector3 spawnPosition = GenerateSpawnPosition(); // ランダムなスポーン位置を取得
        Quaternion rotation = Quaternion.Euler(45, 0, 0);  // 角度調節
        PhotonNetwork.Instantiate(itemPrefab.name, spawnPosition, rotation);
        itemPrefab.SetActive(true);
    }
}
