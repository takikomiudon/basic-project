using UnityEngine;

public class ImageLoader : MonoBehaviour
{
    void Start()
    {
        // Resources.Loadを使用して画像を読み込む
        Sprite mySprite = Resources.Load<Sprite>("/Users/mochidaeijirou/Downloads/shooting_stall_3-768x432.jpg");
        
        // SpriteRendererコンポーネントを持つGameObjectに読み込んだ画像を設定する
        GetComponent<SpriteRenderer>().sprite = mySprite;
    }
}

