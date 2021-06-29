using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cañon : MonoBehaviour
{
    public int cantPolvora;
    public int polvoraNecesaria = 2;
    public GranPorton sptPorton;

    public GameObject spawnParticulas;
    public GameObject particulasDisparo;
    public bool disparo;
    public Animator retrocesoAnim;

    float distanciaFuego;
    GameObject bolaFuego;

    public float tiempoDisparo;
    ParticleSystem chispas;
    bool prenderChispas;

    AudioSource sonido;
    bool activarSonido;

    private void Start()
    {
        retrocesoAnim = GetComponent<Animator>();
        bolaFuego = GameObject.FindGameObjectWithTag("BolaFuego");
        chispas = transform.GetChild(3).GetComponent<ParticleSystem>();
        sonido = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        Disparar();
        DistanciaBolaFuego();
    }

    public void Disparar()
    {
        if (cantPolvora >= polvoraNecesaria)
        {
            if (!prenderChispas)
            {
                chispas.Play();
                prenderChispas = true;
            }
            if(tiempoDisparo <= 0)
            {
                sptPorton.portonDestruido = true;
                InstanciandoParticulas();
                retrocesoAnim.Play("Retroceso");
                cantPolvora = 0;
                if (!activarSonido)
                {
                    sonido.Play();
                    activarSonido = true;
                }
            }
            else
            {
                tiempoDisparo -= Time.deltaTime;
            }
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

    void DistanciaBolaFuego()
    {
        distanciaFuego = Vector3.Distance(transform.position, bolaFuego.transform.position);
        if(distanciaFuego <= 6)
        {
            cantPolvora = 2;
        }
    }
}
