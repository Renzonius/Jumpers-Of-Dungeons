using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //float tiempoSalto;
    //GameObject direccion;

    //public GameObject saltoAtras;
    //public GameObject saltoAdelante;

    //public float distancia = 3f;


    //ParabolaController controladorSalto;

    Vector3 posicionPlataforma;
    public GameObject objetivo;
    public bool moverseAdelante;
    public bool moverseAtras;
    public bool moverseIzq;
    public bool moverseDer;
    public float velocidad = 20f;
    float distanciaSalto = 3f;
    public float esperarSalto = 0.5f;



    void Start()
    {

        //controladorSalto = GetComponent<ParabolaController>();
    }


    private void FixedUpdate()
    {

        if (!moverseAtras && Input.GetKey("w") && !moverseAdelante)
        {
            posicionPlataforma = transform.position + new Vector3(0, 0, 5f);
            moverseAdelante = true;
        }
        else if (!moverseAdelante && Input.GetKey("s") && !moverseAtras)
        {
            posicionPlataforma = transform.position + new Vector3(0, 0, -5f);
            moverseAtras = true;
        }
        //else if (!moverseAdelante && !moverseDer && !moverseIzq && Input.GetKey("d") && !moverseAtras)
        //{
        //    posicionPlataforma = transform.position + new Vector3(5f, 0, 0);
        //    moverseDer = true;
        //}
        //else if (!moverseAdelante && !moverseDer && !moverseIzq && Input.GetKey("a") && !moverseAtras)
        //{
        //    posicionPlataforma = transform.position + new Vector3(-5f, 0, 0);
        //    moverseIzq = true;
        //}

        if (moverseAdelante)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionPlataforma, velocidad * Time.deltaTime);
            esperarSalto -= Time.deltaTime;

            if (transform.position == posicionPlataforma && esperarSalto <= 0)
            {
                esperarSalto = 0.5f;
                moverseAdelante = false;
                posicionPlataforma.z += distanciaSalto;
            }
        }
        else if (moverseAtras)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionPlataforma, velocidad * Time.deltaTime);
            esperarSalto -= Time.deltaTime;

            if (transform.position == posicionPlataforma && esperarSalto <= 0)
            {
                esperarSalto = 0.5f;
                moverseAtras = false;
                posicionPlataforma.z -= distanciaSalto;
            }
        }
        //else if (moverseDer)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, posicionPlataforma, velocidad * Time.deltaTime);
        //    esperarSalto -= Time.deltaTime;

        //    if (transform.position == posicionPlataforma && esperarSalto <= 0)
        //    {
        //        esperarSalto = 0.5f;
        //        moverseDer = false;
        //        posicionPlataforma.z += distanciaSalto;
        //    }
        //}
        //else if (moverseIzq)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, posicionPlataforma, velocidad * Time.deltaTime);
        //    esperarSalto -= Time.deltaTime;

        //    if (transform.position == posicionPlataforma && esperarSalto <= 0)
        //    {
        //        esperarSalto = 0.5f;
        //        moverseIzq = false;
        //        posicionPlataforma.z -= distanciaSalto;
        //    }
        //}
    }





































        //if (Input.GetKey("w")) 
        //{
        //    controladorSalto.ParabolaRoot = saltoAdelante;
        //    controladorSalto.FollowParabola();

        //    //direccion = controladorSalto.ParabolaRoot; //ADAPTAR PARA QUE ELIJA UNA DE LAS RUTAS (ATRAS, ADELANTE)
        //    //controladorSalto.FollowParabola();

        //    //GetComponent<ParabolaController>().FollowParabola();
        //}
        //else if (Input.GetKey("s"))
        //{
        //    controladorSalto.ParabolaRoot = saltoAtras;
        //    controladorSalto.FollowParabola();
        //    //direccion = controladorSalto.ParabolaRoot[1];
        //}



        //if (Input.GetKey("w"))
        //{

        //    tiempoSalto += Time.deltaTime;

        //    tiempoSalto = tiempoSalto % 3f;

        //    transform.position = CalculoTrayectoria(transform.position, tiempoSalto);

        //    transform.position = MathParabola.Parabola(Vector3.zero, Vector3.forward * 3f, 2f, tiempoSalto / 2f);
        //}
        //tiempoSalto += Time.deltaTime;

        //tiempoSalto = tiempoSalto % 3f;

        //transform.position = CalculoTrayectoria(transform.position, tiempoSalto);

        



//    public Vector3 CalculoTrayectoria(Vector3 posicion, float tiempoSalto)
//    {
//        posicion = MathParabola.Parabola(transform.position, Vector3.forward * distancia, 1f, tiempoSalto / 2f);

//        distancia += 3f*Time.deltaTime;

//        return posicion;
//    }
}
