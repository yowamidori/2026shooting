using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyredbeam : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Õ“Ë‘Šè‚ª"enemy"ƒ^ƒO‚È‚ç
        if (other.CompareTag("Player"))
        {
            // ©•ª©g(’e)‚ğÁ‚·
            Destroy(gameObject);
        }
    }
}
