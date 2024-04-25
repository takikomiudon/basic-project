using UnityEngine;
using TMPro;

public class MyScript : MonoBehaviour
{
    // TextMeshProオブジェクトの参照
    public TextMeshProUGUI life;

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
}
