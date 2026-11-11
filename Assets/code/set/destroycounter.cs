using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 弾が敵に命中した回数をカウントし、規定回数に達したらシーンを遷移させる。
/// 空のGameObject（例:"GameManager"）にアタッチして使用する。
/// </summary>
public class HitCounter : MonoBehaviour
{
    // どこからでも HitCounter.Instance でアクセスできるようにする
    public static HitCounter Instance { get; private set; }

    [Header("命中カウント設定")]
    [Tooltip("シーン移行に必要な命中回数")]
    [SerializeField] private int requiredHitCount = 10;

    [Header("シーン遷移設定")]
    [Tooltip("命中回数達成後に移行するシーン名（Build Settingsに登録が必要）")]
    [SerializeField] private string nextSceneName = "ClearScene";

    private int currentHitCount = 0;
    private bool hasTransitioned = false;

    private void Awake()
    {
        // シーン内に重複して存在しないようにする
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    /// <summary>
    /// 弾が敵にヒットした際に呼び出す。命中数を1増やし、規定数に達したらシーン遷移する。
    /// </summary>
    public void RegisterHit()
    {
        if (hasTransitioned) return;

        currentHitCount++;
        Debug.Log($"命中数: {currentHitCount} / {requiredHitCount}");

        if (currentHitCount >= requiredHitCount)
        {
            hasTransitioned = true;
            SceneManager.LoadScene(nextSceneName);
        }
    }

    public int CurrentHitCount => currentHitCount;
    public int RequiredHitCount => requiredHitCount;
}