using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenshot : MonoBehaviour
{
    public GameObject shellPrefab;
    private int count;

    void Update()
    {
        {
            count += 1;

            // iƒ|ƒCƒ“ƒgj
            // ƒtƒŒ[ƒ€‚ª20‚Ì”{”‚Ì‚É–C’e‚ğ”­Ë‚·‚é
            if (count % 20 == 0)
            {
                GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);
                Rigidbody shellRb = shell.GetComponent<Rigidbody>();

                // ’e‘¬‚Í©—R‚Éİ’è
                shellRb.AddForce(transform.forward * 1500);



                // ‚T•bŒã‚É–C’e‚ğ”j‰ó‚·‚é
                Destroy(shell, 5.0f);
            }
        }
    }
}