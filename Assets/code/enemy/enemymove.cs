using UnityEngine;

public class PingPongMove : MonoBehaviour
{
    [SerializeField] private Vector3 pointA; // 地点A
    [SerializeField] private Vector3 pointB; // 地点B
    [SerializeField] private float speed = 2f;   // 移動速度

    private void Update()
    {
        // 経過時間から0~1の間の往復する値を作る
        float time = Mathf.PingPong(Time.time * speed, 1f);
        // 2点間を補間して位置を決定
        transform.position = Vector3.Lerp(pointA, pointB, time);
    }
}
