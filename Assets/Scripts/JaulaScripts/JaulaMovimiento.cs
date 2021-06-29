using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaulaMovimiento : MonoBehaviour
{
    public Activador sptActivador;
    public GameObject activadorRef;

    public GameObject desactivadorRef;
    public Desactivador sptDesactivador;

    Vector3 posLocalObst;
    public float tiempoActivo;
    public float tiempoAutoDesactivar;

    public GameObject obstaculoRef;
    public Vector3 posInicialObst;
    public Vector3 posBlequeoObst;
    public float velBajada;
    public float velSubida;
    public bool obstActivado;

    public bool posibilitarDesactivar;

    public ParticleSystem chispas;
    public bool particulasEmitidas;

    public Animator animator;

    void Movimiento()
    {
        if (obstActivado && tiempoAutoDesactivar >0)
        {
            obstaculoRef.transform.localPosition = Vector3.MoveTowards(obstaculoRef.transform.localPosition, posBlequeoObst, velBajada * Time.deltaTime);
            if (obstaculoRef.transform.localPosition == posBlequeoObst && !particulasEmitidas)
            {
                chispas.Play();
                particulasEmitidas = true;
            }
                animator.SetBool("efecto", true);
        }
        else
        {
            obstaculoRef.transform.localPosition = Vector3.MoveTowards(obstaculoRef.transform.localPosition, posInicialObst, velSubida * Time.deltaTime);
            animator.SetBool("efecto", false);
            obstActivado = false;
        }
    }

    void Start()
    {
        //Asignamos la jaula
        obstaculoRef = gameObject.transform.GetChild(0).gameObject;

        //Asignamos el activador
        activadorRef = gameObject.transform.GetChild(1).gameObject;
        sptActivador = activadorRef.GetComponent<Activador>();

        //Asignamos el desactivador
        desactivadorRef = gameObject.transform.GetChild(2).gameObject;
        sptDesactivador = desactivadorRef.GetComponent<Desactivador>();


        posLocalObst = obstaculoRef.transform.localPosition;
        posInicialObst = posLocalObst;
        posBlequeoObst = new Vector3(posInicialObst.x, -1f, 0f);
        velBajada = 30f;
        velSubida = 15f;
        tiempoActivo = 1f;
        tiempoAutoDesactivar = 7f;

        chispas = transform.GetChild(3).gameObject.GetComponent<ParticleSystem>();
        animator = GetComponent<Animator>();
    }

    void TiempoActivado()
    {
        if (obstActivado && tiempoActivo > 0)
        {
            tiempoActivo -= Time.deltaTime;
        }
        if(tiempoActivo <= 0)
        {
            posibilitarDesactivar = true;
        }
    }

    void FixedUpdate()
    {
        if (tiempoAutoDesactivar > 0 && obstActivado)
        {
            tiempoAutoDesactivar -= Time.deltaTime;
        }
        Movimiento();
        TiempoActivado();
    }
}
