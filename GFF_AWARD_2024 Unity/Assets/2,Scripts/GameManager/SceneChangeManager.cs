using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    /// <summary>
    /// シーン遷移を管理するシングルトン
    /// </summary>

    // シングルトンのインスタンスを保持するプロパティ
    public static SceneChangeManager Instance { get; private set; }

    // インスペクターで設定可能なシーン名のリスト　シーン名を事前に登録しておく
    [Header("使用するシーン名をリストに登録")]
    public List<string> SceneNames = new List<string>();

    private void Awake()
    {
        // シングルトンパターンの実装
        // インスタンスが存在しなければ、このオブジェクトをシングルトンとして設定
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーンが変わってもこのオブジェクトを破棄しない
        }
        else
        {
            Destroy(gameObject); // 既にインスタンスが存在する場合は、このオブジェクトを破棄
        }
    }

    // 指定されたシーンに遷移するメソッド
    public void ChangeSceneLoad(string sceneName) // 引数sceneNameは他スクリプトから指定
    {
        // 指定されたシーン名がリストに含まれているかチェック
        if (SceneNames.Contains(sceneName))
        {
            SceneManager.LoadScene(sceneName); // 引数からシーンをロード
        }
        else
        {
            // リストにシーン名が含まれていない場合はエラーメッセージを表示
            Debug.LogError($"There is no {sceneName} scene in the list.  リスト内にシーンが含まれていません。");
        }
    }

    // シーン遷移を遅延させるメソッド
    public IEnumerator ChangeSceneLoad(string sceneName , float changetime) // 引数sceneNameは他スクリプトから指定
    {
        // 指定されたシーン名がリストに含まれているかチェック
        if (SceneNames.Contains(sceneName))
        {
            yield return new WaitForSeconds(changetime); // 指定した時間待機
            SceneManager.LoadScene(sceneName); // 引数からシーンをロード
        }
        else
        {
            // リストにシーン名が含まれていない場合はエラーメッセージを表示
            Debug.LogError($"There is no {sceneName} scene in the list.  リスト内にシーンが含まれていません。");
        }
    }

    // メモ：タイトル画面やステージセレクトマップなど、頻繁に利用するシーンは
    //       メソッドでいつでも呼び出せるようにする

    // シーン移動：タイトル
    public void OnTitle()
    {
        ChangeSceneLoad("TitleScene");
    }
    public void OnTitle(float timer) // (他スクリプトから時間指定可能)
    {
        StartCoroutine(ChangeSceneLoad("TitleScene", timer));
    }
}