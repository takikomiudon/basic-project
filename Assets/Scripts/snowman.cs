using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyScript : MonoBehaviour
{
    public Renderer renderer;
    private bool isBlinking = false;

    // TextMeshProオブジェクトの参照
    public TextMeshProUGUI life;

    /*
    // 当たった時に呼ばれる関数
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Red Ball(Clone)")
        {
            // 名前が "name" のオブジェクトに当たった場合、TextMeshProの数値を1減らす
            int currentValue = int.Parse(life.text);
            life.text = (currentValue - 1).ToString();
        }
    }
    */

    IEnumerator BlinkObject(float duration)
    {
        isBlinking = true;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // オブジェクトの表示/非表示を交互に切り替えることで点滅を実現
            renderer.enabled = !renderer.enabled;
            
            // 0.1秒待機
            yield return new WaitForSeconds(0.1f);
            elapsedTime += 0.1f;
        }

        // 点滅が終了した後、オブジェクトの表示を元に戻す
        renderer.enabled = true;
        

        isBlinking = false;
    }

    // 当たった時に呼ばれる関数
    void OnCollisionEnter(Collision collision)
    {
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
}
