using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // TextMeshProを使う場合は不要
using TMPro; // TextMeshProのために必要

public class ButtonClickHandler : MonoBehaviour
{

    // シーン名をインスペクターから設定できるようにする
    public string overlaySceneName { get; private set; }
    /* メモ：変数に{ get; private set; }と記述すると、
            publicでも他スクリプトからは変更不可にできる。
     　　　  外部のスクリプトからの不要な変更を防ぐために記述する。 */


    // インスペクターでシーンを表示させる操作にするか非表示にする操作にするかを選択できる
    [Header("true:指定したオーバーレイシーン読み込み false:指定したオーバーレイシーン削除")]
    public bool showOverlay = true;

    // Startメソッドでボタンのクリックイベントを設定する
    private void Start()
    {
        // TextMeshProのButtonコンポーネントを取得
        var button = GetComponent<Button>();

        // ボタンが存在する場合、OnClickイベントにメソッドを登録
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogError("Button component not found.");
        }
    }

    // ボタンがクリックされたときに呼び出されるメソッド
    private void OnButtonClick()
    {
        // OverlayManagerのインスタンスが存在するか確認
        if (OverlayManager.Instance != null)
        {
            if (showOverlay)
            {
                // OverlayManagerのShowOverlaySceneメソッドを呼び出し
                OverlayManager.Instance.ShowOverlayScene(overlaySceneName);
            }
            else
            {
                // OverlayManagerのHideOverlaySceneメソッドを呼び出し
                OverlayManager.Instance.HideOverlayScene(overlaySceneName);
            }
        }
        else
        {
            Debug.LogError("OverlayManager instance not found.");
        }
    }
}