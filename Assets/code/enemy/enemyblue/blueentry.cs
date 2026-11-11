using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueentry : MonoBehaviour
{
    public GameObject shellPrefab;
    private int count;

    void Update()
    {
        {
            count += 1;

            // （ポイント）
            // フレームが55の倍数の時に敵を出現させる
            if (count % 55 == 0)
            {
                GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);
                Rigidbody shellRb = shell.GetComponent<Rigidbody>();

                // 速度は自由に設定
                shellRb.AddForce(transform.forward * 600);



                // 30秒後に敵を破壊する
                Destroy(shell, 30.0f);
            }
        }
    }
}
