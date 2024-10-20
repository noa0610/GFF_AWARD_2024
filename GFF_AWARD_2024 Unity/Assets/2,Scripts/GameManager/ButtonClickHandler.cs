using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // TextMeshProを使う場合は不要
using TMPro; // TextMeshProのために必要

public class ButtonClickHandler : MonoBehaviour
{

    // シーン名をインスペクターから設定できるようにする
    public string overlaySceneName;

    // インスペクターでシーンを表示するか非表示にするかを選択できる
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