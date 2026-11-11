using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーが弾(redbeam)に当たるたびに、右端のハートから順番に消していくスクリプト。
/// このスクリプトは「Player」タグが付いたオブジェクト(コライダーはIs Trigger)にアタッチする。
/// </summary>
public class Playerhearts : MonoBehaviour
{
    [Header("ハートオブジェクトを左から右の順番でセットする")]
    [SerializeField] private GameObject[] hearts; // Inspectorで4つ、左→右の順にドラッグ&ドロップ

    private int currentHeartIndex; // 現在消すべきハートのインデックス(右端から)

    void Start()
    {
        // 配列の最後(＝一番右のハート)からスタート
        currentHeartIndex = hearts.Length - 1;
    }

    // 3Dのコライダー同士がIs Triggerで衝突した際に呼ばれる
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("redbeam"))
        {
            return; // redbeam以外のタグは無視
        }

       

        // まだ消せるハートが残っている場合
        if (currentHeartIndex >= 0)
        {
            hearts[currentHeartIndex].SetActive(false);
            currentHeartIndex--;
        }

        // 全部消えたらゲームオーバー処理
        if (currentHeartIndex < 0)
        {
            Debug.Log("ハートが全て無くなりました。ゲームオーバー処理をここに書く。");
            // 例: GameManager.Instance.GameOver();
        }
    }
}
