using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HileraItems : MonoBehaviour
{
    public GameObject[] items;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("MuroFuego"))
        {
            Destroy(gameObject);
        }
    }

}
