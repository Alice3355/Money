using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Money
{
    /// <summary>
    /// 解像度の固定
    /// </summary>
    [RequireComponent(typeof(RectTransform))]
    public class SafeAreaFitter : MonoBehaviour
    {
        private void Awake()
        {
            RectTransform rectTransform = GetComponent<RectTransform>();
            // デバイスの画面サイズ取得
            Vector2 screenSize = new Vector2(Screen.width, Screen.height);
            // しっかりUIが見える範囲
            Rect deviceSafeArea = Screen.safeArea;

            // 左下の端の位置
            Vector2 anchorMin = deviceSafeArea.position;
            // 右上の端の位置
            Vector2 anchorMax = deviceSafeArea.position + deviceSafeArea.size;

            // デバイスの安全領域の座標をスクリーン全体のサイズに対する割合に変換している
            anchorMin.x /= screenSize.x;
            anchorMax.x /= screenSize.x;
            anchorMin.y /= screenSize.y;
            anchorMax.y /= screenSize.y;

            // 位置を固定
            rectTransform.anchoredPosition = Vector2.zero;
            rectTransform.sizeDelta = Vector2.zero;

            // 大きさ変更
            rectTransform.anchorMin = anchorMin;
            rectTransform.anchorMax = anchorMax;
        }
    }
}
