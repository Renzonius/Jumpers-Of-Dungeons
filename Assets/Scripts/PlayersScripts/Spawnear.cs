using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawnear : MonoBehaviour
{
    public bool activarSpawn;
    public float tiempoSpawn;
    public Vector3 coordSpawn;

    GameObject cuerpoRef;

    MovimientoGeneral movimientoSpt;

    public GameObject marcadorSpawn;

    public GameObject particulasMonedas;

    Animator animator;

    void SpawnearJugador()
    {
        tiempoSpawn -= Time.deltaTime;
        if (tiempoSpawn < 1)
        {
            animator.SetBool("caida", false);
            transform.position = coordSpawn;
            cuerpoRef.SetActive(true);
            movimientoSpt.enabled = true;
            movimientoSpt.sinMovimiento = false;
            tiempoSpawn = 3f;
            activarSpawn = false;
        }
    }

    void Start()
    {
        movimientoSpt = GetComponent<MovimientoGeneral>();
        tiempoSpawn = 3f;
        coordSpawn = transform.position;
        cuerpoRef = gameObject.transform.GetChild(0).gameObject;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (activarSpawn)
        {
            SpawnearJugador();
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        string tipoTag = col.gameObject.tag;
        switch (tipoTag)
        {
            case "Oscuridad":
                Instantiate(particulasMonedas, transform.position, particulasMonedas.transform.rotation);
                activarSpawn = true;
                cuerpoRef.SetActive(false);
                Instantiate(marcadorSpawn, coordSpawn + new Vector3(0,2f,0), marcadorSpawn.transform.rotation);
                break;
            default:
                break;
        }

    }

    private void OnCollisionExit(Collision col)
    {
        string tipoTag = col.gameObject.tag;
        switch (tipoTag)
        {
            case "Suelo":
                coordSpawn = col.gameObject.transform.position;
                break;
            default:
                break;
        }
    }
}
