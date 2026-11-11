using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fps : MonoBehaviour
{
    void Awake()
    {
        // 垂直同期を無効化(VSyncが有効だとTargetFrameRateが無視される)
        QualitySettings.vSyncCount = 0;

        // フレームレートを30に固定
        Application.targetFrameRate = 30;
    }
}
