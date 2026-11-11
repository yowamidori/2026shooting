using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShotShell : MonoBehaviour
{
    public GameObject shellPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();
            shellRb.AddForce(Vector3.forward * 1500);
            Destroy(shell, 5);
        }
    }
}