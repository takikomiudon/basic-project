using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class item_contriller : MonoBehaviour
{
    public GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        PhotonNetwork.Destroy(car);
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
