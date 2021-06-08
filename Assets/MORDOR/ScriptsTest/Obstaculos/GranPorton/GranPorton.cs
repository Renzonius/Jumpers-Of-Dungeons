using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranPorton : MonoBehaviour
{
    public bool portonDestruido;
    public Animator anim;
    BoxCollider colliderRef;
    public MovimientoGeneral sptPlayer1;
    public MovimientoGeneral sptPlayer2;

    public GameObject puertaRotaDerRef;
    public GameObject puertaRotaIzqRef;

    public GameObject puertaDerRef;
    public GameObject puertaIzqRef;

    public GameObject BarrilPolvoraIzqRef;
    public GameObject BarrilPolvoraDerRef;


    public GameObject explosion;
    public bool explotar;
    public GameObject centroExplosion;
    void Start()
    {
        colliderRef = gameObject.GetComponent<BoxCollider>();
        sptPlayer1 = GameObject.FindGameObjectWithTag("Player").GetComponent<MovimientoGeneral>();
        sptPlayer2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<MovimientoGeneral>();
    }

    void FixedUpdate()
    {
        AbrirPorton();
    }

    public void AbrirPorton()
    {
        if (portonDestruido)
        {

            anim.Play("AbrirGranPorton");
            colliderRef.enabled = false;
            puertaDerRef.SetActive(false);
            puertaIzqRef.SetActive(false);
            puertaRotaDerRef.SetActive(true);
            puertaRotaIzqRef.SetActive(true);
            sptPlayer1.caminoBloqueado = false;
            sptPlayer2.caminoBloqueado = false;
            BarrilPolvoraIzqRef.SetActive(false);
            BarrilPolvoraDerRef.SetActive(false);
            InstanciarExplosion();
            //if(Mathf.Round(alaIzquierda.transform.eulerAngles.y) != 280)
            //{ 
            //    alaIzquierda.transform.Rotate(new Vector3(0, 10 * -velApertura,0));
            //    Debug.Log(Mathf.Round(alaIzquierda.transform.eulerAngles.y));

            //    alaDerecha.transform.Rotate(new Vector3(0, 10 * velApertura, 0));
            //    Debug.Log(Mathf.Round(alaIzquierda.transform.eulerAngles.y));
            //}
        }
    }
    void InstanciarExplosion()
    {
        if (!explotar)
        {
            Instantiate(explosion, centroExplosion.transform.position, centroExplosion.transform.rotation);
            explotar = true;
        }
    }

    //private void OnTriggerEnter(Collider col)
    //{
    //    if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Player2"))
    //    {
    //        sptPlayer = col.GetComponent<Player>();
    //    }
    //}
}