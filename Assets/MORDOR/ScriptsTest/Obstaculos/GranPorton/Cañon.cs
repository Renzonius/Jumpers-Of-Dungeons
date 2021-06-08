using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cañon : MonoBehaviour
{
    public int cantPolvora;
    public int polvoraNecesaria;
    public GranPorton sptPorton;

    public GameObject spawnParticulas;
    public GameObject particulasDisparo;
    bool disparo;
    public Animator retrocesoAnim;


    
    private void Start()
    {
        retrocesoAnim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Disparar();
    }

    public void Disparar()
    {
        if (cantPolvora >= polvoraNecesaria)
        {
            sptPorton.portonDestruido = true;
            InstanciandoParticulas();
            retrocesoAnim.Play("Retroceso");
            cantPolvora = 0;
        }
    }

    public void InstanciandoParticulas()
    {
        if (!disparo)
        {
            Instantiate(particulasDisparo, spawnParticulas.transform.position, spawnParticulas.transform.rotation);
            disparo = true;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "BolaFuego")
        {
            cantPolvora = 6;
            Debug.Log("Coliciono con bola de fuego");
        }
    }
}
