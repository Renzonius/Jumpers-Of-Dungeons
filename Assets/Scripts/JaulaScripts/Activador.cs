using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activador : MonoBehaviour
{
    [SerializeField] private bool _activado;
    public bool activado { get { return _activado; } set { _activado = value; } }
    BoxCollider colliderRef;
    JaulaMovimiento sptJaula;

    SpriteRenderer sennalAtrapadoP1;
    SpriteRenderer sennalAtrapadoP2;

    private void Start()
    {
        colliderRef = GetComponent<BoxCollider>();
        sptJaula = gameObject.transform.GetComponentInParent<JaulaMovimiento>();
        sennalAtrapadoP1 = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        sennalAtrapadoP2 = transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();
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
        if (col.gameObject.CompareTag("Player"))
        {
            sennalAtrapadoP1.color = new Color(255f, 255f, 255f, 255f);
        }
        else if (col.gameObject.CompareTag("Player2"))
        {
            sennalAtrapadoP2.color = new Color(255f, 255f, 255f, 255f);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Player2"))
        {
            colliderRef.enabled = false;
        }
        if (col.gameObject.CompareTag("Player"))
        {
            sennalAtrapadoP1.color = new Color(255f, 255f, 255f, 0f);
        }
        else if (col.gameObject.CompareTag("Player2"))
        {
            sennalAtrapadoP2.color = new Color(255f, 255f, 255f, 0f);
        }
    }
}
