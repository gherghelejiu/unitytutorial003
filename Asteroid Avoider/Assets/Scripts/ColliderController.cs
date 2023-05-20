using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (null == playerHealth) { return; }

        playerHealth.Crash();
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
