using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainImage : MonoBehaviour
{
    public Image UIobj;
    public ShootShell shootshell;
    float remain;

    

    // Start is called before the first frame update
    void Start()
    {
        //ShootShell shootshell = GetComponent<ShootShell>();
        shootshell = FindObjectOfType<ShootShell>();
        remain = shootshell.remainShoot;
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {
        // ShootShellクラスのインスタンスを取得する
        //ShootShell shootshell = GetComponent<ShootShell>();

        // インスタンスのremainShootプロパティにアクセスし、その値を取得する
        //float remain = shootshell.remainShoot;
        //remain = ShootShell.remainShoot;

        //Debug.Log("update remain "+remain);

        // 取得した値を使ってUIobjのfillAmountを設定する
        //UIobj.fillAmount = remain / 6;
    }


}
