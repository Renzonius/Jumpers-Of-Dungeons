using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activador : MonoBehaviour
{
    [SerializeField] private bool _activado;
    public bool activado { get { return _activado; } set { _activado = value; } }
    BoxCollider colliderRef;
    JaulaMovimiento sptJaula;

    private void Start()
    {
        colliderRef = GetComponent<BoxCollider>();
        sptJaula = gameObject.transform.GetComponentInParent<JaulaMovimiento>();
    }

    private void FixedUpdate()
    {
        if (!sptJaula.obstActivado)
        {
            activado = false;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Player2"))
        {
            activado = true;
            sptJaula.obstActivado = true;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Player2"))
        {
            colliderRef.enabled = false;
        }
    }
}
