using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ganar : MonoBehaviour
{
    public bool salidaJugador;
    public bool portalJugador;

    public float velocidadCorrer;

    public Vector3 posicion;
    public GameObject portal;

    Animator animator;

    public GameObject cuerpo;
    CapsuleCollider colRef;

    void Start()
    {
        portal = GameObject.FindGameObjectWithTag("Portal");
        animator = GetComponent<Animator>();
        cuerpo = transform.GetChild(0).gameObject;
        colRef = GetComponent<CapsuleCollider>();
    }

    void FixedUpdate()
    {
        CorrerHaciaPortal();
    }

    void CorrerHaciaPortal()
    {
        if (salidaJugador)
        {
            if (!portalJugador)
            {
                posicion = Vector3.MoveTowards(transform.position, portal.transform.position, velocidadCorrer * Time.deltaTime);
                transform.position = posicion;
            }
            animator.SetBool("correr", true);
            animator.SetBool("dash", false);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Salida"))
        {
            salidaJugador = true;
        }
        else if (col.gameObject.CompareTag("Portal"))
        {
            cuerpo.SetActive(false);
            colRef.enabled = false;
            portalJugador = true;
        }
    }
}
