using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerarrow : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 minpos;
    public Vector3 maxpos;
    public Camera mainCamera;      // 透視投影のメインカメラ
    public RectTransform reticle;  // UIレティクル(Canvas上のImage等)

    void Start()
    {
        if (mainCamera == null) mainCamera = Camera.main;
    }

    void Update()
    {
        // --- プレイヤー移動(十字キーのみ) ---
        float x = 0f;
        float y = 0f;

        if (Input.GetKey(KeyCode.LeftArrow)) x -= 1f;
        if (Input.GetKey(KeyCode.RightArrow)) x += 1f;
        if (Input.GetKey(KeyCode.UpArrow)) y += 1f;
        if (Input.GetKey(KeyCode.DownArrow)) y -= 1f;

        Vector3 input = new Vector3(x, y, 0);
        transform.position += input * speed * Time.deltaTime;

        float clampedX = Mathf.Clamp(transform.position.x, minpos.x, maxpos.x);
        float clampedY = Mathf.Clamp(transform.position.y, minpos.y, maxpos.y);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

        // --- レティクル同期 ---
        Vector3 screenPos = mainCamera.WorldToScreenPoint(transform.position);
        reticle.position = screenPos;
    }
}