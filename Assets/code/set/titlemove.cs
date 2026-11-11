using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titlemove : MonoBehaviour
{
    [Header("遷移先シーン名")]
    [Tooltip("Build Settingsに登録されているシーン名を入力してください")]
    [SerializeField] private string sceneName;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (!string.IsNullOrEmpty(sceneName))
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                Debug.LogWarning("遷移先のシーン名が設定されていません。");
            }
        }
    }
}
