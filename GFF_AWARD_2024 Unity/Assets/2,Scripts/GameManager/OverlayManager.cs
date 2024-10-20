using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverlayManager : MonoBehaviour
{
    /// <summary>
    /// シーンオーバーレイを管理するシングルトン
    /// </summary>

    // シングルトンのインスタンスを保持するプロパティ
    public static OverlayManager Instance { get; private set; }

    // インスペクターで設定可能なシーン名のリスト
    // シーン名を事前に登録しておき、指定されたシーンのみをオーバーレイ表示する
    public List<string> overlaySceneNames = new List<string>();

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

    // シーンをオーバーレイ（追加読み込み）するメソッド
    public void ShowOverlayScene(string sceneName)
    {
        // 指定されたシーン名がリストに含まれているかチェック
        if (overlaySceneNames.Contains(sceneName))
        {
            // シーンがまだロードされていない場合のみ追加読み込みを行う
            if (!SceneManager.GetSceneByName(sceneName).isLoaded)
            {
                SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            }
            else
            {
                // 既にシーンがロードされている場合は警告メッセージを表示
                Debug.LogWarning($"Scene {sceneName} is already loaded.");
            }
        }
        else
        {
            // リストにシーン名が含まれていない場合はエラーメッセージを表示
            Debug.LogError($"Scene {sceneName} is not found in the overlay list.");
        }
    }

    // オーバーレイされているシーンを非表示（アンロード）するメソッド
    public void HideOverlayScene(string sceneName)
    {
        // 指定されたシーン名がリストに含まれているかチェック
        if (overlaySceneNames.Contains(sceneName))
        {
            // シーンが現在ロードされている場合のみアンロードを行う
            if (SceneManager.GetSceneByName(sceneName).isLoaded)
            {
                SceneManager.UnloadSceneAsync(sceneName);
            }
            else
            {
                // シーンがロードされていない場合は警告メッセージを表示
                Debug.LogWarning($"Scene {sceneName} is not currently loaded.");
            }
        }
        else
        {
            // リストにシーン名が含まれていない場合はエラーメッセージを表示
            Debug.LogError($"Scene {sceneName} is not found in the overlay list.");
        }
    }
}