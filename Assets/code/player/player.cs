using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
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
        // --- プレイヤー移動 ---
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.position += input * speed * Time.deltaTime;

        float clampedX = Mathf.Clamp(transform.position.x, minpos.x, maxpos.x);
        float clampedY = Mathf.Clamp(transform.position.y, minpos.y, maxpos.y);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

        // --- レティクル同期 ---
        Vector3 screenPos = mainCamera.WorldToScreenPoint(transform.position);
        reticle.position = screenPos;
    }
}