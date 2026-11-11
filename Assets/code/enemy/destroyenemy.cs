using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroynemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 衝突相手が"bluebeam"タグなら
        if (other.CompareTag("bluebeam"))
        {
            // 命中カウントを+1
            HitCounter.Instance.RegisterHit();

            // 自分自身(敵)を消す
            Destroy(gameObject);
        }
    }
}
