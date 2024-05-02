using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainImage : MonoBehaviour
{
    public Image UIobj;
    float remain;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ShootShellクラスのインスタンスを取得する
        ShootShell shootshell = GetComponent<ShootShell>();
        if (shootshell == null)
        {
            Debug.Log("null");
            return;
        }
        remain = shootshell.remainShoot;

        // 取得した値を使ってUIobjのfillAmountを設定する
        UIobj.fillAmount = remain / 6;
    }


}
