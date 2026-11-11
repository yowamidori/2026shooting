using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // レガシーTextを使うために必要

/// <summary>
/// HitCounterのヒット数を監視し、Legacy Text (UI.Text) に「撃破数:数字」として表示する。
/// UI Canvas内のTextオブジェクトにアタッチして使用する。
/// </summary>
public class HitCountDisplay : MonoBehaviour
{
    [Header("表示先のText")]
    [Tooltip("撃破数を表示するレガシーTextコンポーネント")]
    [SerializeField] private Text hitCountText;

    [Header("表示フォーマット")]
    [Tooltip("数字の前に付ける文字列")]
    [SerializeField] private string prefix = "撃破数:";

    private int lastDisplayedCount = -1; // 前回表示した値（無駄な更新を避けるため）

    private void Start()
    {
        // 初期表示（0スタート）
        UpdateDisplay(0);
    }

    private void Update()
    {
        if (HitCounter.Instance == null) return;

        int currentCount = HitCounter.Instance.CurrentHitCount;

        // 値が変わったときだけ更新
        if (currentCount != lastDisplayedCount)
        {
            UpdateDisplay(currentCount);
        }
    }

    private void UpdateDisplay(int count)
    {
        if (hitCountText != null)
        {
            hitCountText.text = prefix + count;
        }
        lastDisplayedCount = count;
    }
}