using UnityEngine;

public class WorldRotatePingPong : MonoBehaviour
{
    [Header("最大角度（度）")]
    public float angle = 45f;
    [Header("往復の速さ")]
    public float speed = 2f;
    [Header("回転させたいワールド軸")]
    public Vector3 worldAxis = Vector3.up; // Vector3.up は Y軸 (0, 1, 0)

    private Quaternion initialRotation;

    void Start()
    {
        // ゲーム開始時の初期回転を保存
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // 時間経過に合わせてSin波で角度を計算
        float currentAngle = Mathf.Sin(Time.time * speed) * angle;

        // ワールド軸を基準とした回転量を作成
        Quaternion worldRotation = Quaternion.AngleAxis(currentAngle, worldAxis);

        // 初期回転に対して、ワールド空間の回転を適用する
        transform.rotation = worldRotation * initialRotation;
    }
}