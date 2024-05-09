using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ItemSpawner : MonoBehaviourPunCallbacks
{
    public GameObject itemPrefab; // アイテムのプレファブ
    public float spawnInterval = 10f; // アイテムが生成される時間間隔（秒）
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

    // 当たった時に呼ばれる関数
    void OnCollisionEnter(Collision collision)
    {
        PhotonNetwork.Destroy(item);
        Debug.Log("item_collision");

    }



    void SpawnItem()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(24f, 25f), 2, Random.Range(-10f, -9f));
        item = PhotonNetwork.Instantiate(itemPrefab.name, spawnPosition, Quaternion.identity) as GameObject;
        itemPrefab.SetActive(true);

        
    }
}
