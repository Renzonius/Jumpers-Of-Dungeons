using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raton : MonoBehaviour
{
    public float velMovimiento;
    public float tiempoEspera;
    public float valorTiempo;
    public GameObject posBRef;
    public GameObject posARef;
    public GameObject ratonRef;
    public Vector3 posB;
    public Vector3 posA;
    public Vector3 posActual;
    public Vector3[] posiciones;
    public int valorMaxPos;
    public bool enPosicion;
    int valor;

    Animator animator;

    void Start()
    {
        valor = 0;
        tiempoEspera = 3f;
        posB = transform.GetChild(2).gameObject.transform.localPosition;
        posA = transform.GetChild(1).gameObject.transform.localPosition;
        posActual = ratonRef.transform.localPosition;

        //posiciones[0] = transform.localPosition;
        //posiciones[1] = posA;
        //posiciones[2] = posB;

        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Movimiento();   
    }

    public void Movimiento()
    {
        if (!enPosicion)
        {
            posActual = Vector3.MoveTowards(posActual, posiciones[valor], velMovimiento * Time.deltaTime);
            ratonRef.transform.localPosition = posActual;

            if (posActual == posiciones[0] || posActual == posiciones[1] || posActual == posiciones[2])
            {
                enPosicion = true;
                animator.SetBool("correr", false);
                if (posActual == posiciones[2])
                {
                    tiempoEspera = 5;
                }
            }
        }
        else
        {
            tiempoEspera -= Time.deltaTime;
            if (tiempoEspera <= 0f)
            {
                tiempoEspera = valorTiempo;
                enPosicion = false;
                animator.SetBool("correr", true);
                if (valor >= valorMaxPos)
                {
                    valor = 0;
                    ratonRef.transform.LookAt(transform.position);
                }
                else
                {
                    valor++;
                    ratonRef.transform.LookAt(posBRef.transform.position);
                }
                //switch (valor)
                //{
                //    case 0:
                //        valor++;
                //        ratonRef.transform.LookAt(transform.position);
                //        break;
                //    case 1:
                //        valor++;
                //        ratonRef.transform.LookAt(posARef.transform.position);
                //        break;
                //    case 2:
                //        valor = 0;
                //        ratonRef.transform.LookAt(posBRef.transform.position);
                //        break;
                //}
            }
        }
    }
}
