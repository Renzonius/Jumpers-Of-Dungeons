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
    Rigidbody rigidRef;

    void Start()
    {
        portal = GameObject.FindGameObjectWithTag("Portal");
        animator = GetComponent<Animator>();
        cuerpo = transform.GetChild(0).gameObject;
        colRef = GetComponent<CapsuleCollider>();
        rigidRef = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        CorrerHaciaPortal();
        if (portalJugador)
        {
            ReseteadorPosicion();
        }
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

    void ReseteadorPosicion()
    {
        if(transform.position.y < -7f)
        {
            transform.position = portal.transform.position;
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
            rigidRef.useGravity = false;
            portalJugador = true;
        }
    }
}
