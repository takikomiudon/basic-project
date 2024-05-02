using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ライブラリの追加
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class restartButton : MonoBehaviour {	
    // 始まった時に実行する関数	
    void Start () { 
        // ボタンが押された時、StartGame関数を実行 
        gameObject.GetComponent<Button>().onClick.AddListener(StartGamescene);	} 
        // StartGame関数 
        void StartGamescene() { // GameSceneをロード 
        SceneManager.LoadScene("NewStartscene"); }
}
