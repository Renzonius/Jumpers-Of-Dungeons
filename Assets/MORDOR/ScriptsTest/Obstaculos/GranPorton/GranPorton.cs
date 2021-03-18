using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranPorton : MonoBehaviour
{
    public bool portonDestruido;
    public Animator anim;
    BoxCollider colliderRef;
    public ControlPlayerUno sptPlayer1;
    public ControlPlayerDos sptPlayer2;

    public GameObject BarrilPolvoraIzqRef;
    public GameObject BarrilPolvoraDerRef;

    void Start()
    {
        colliderRef = gameObject.GetComponent<BoxCollider>();
        sptPlayer1 = GameObject.FindGameObjectWithTag("Player").GetComponent<ControlPlayerUno>();
        sptPlayer2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<ControlPlayerDos>();
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
            sptPlayer1.caminoBloqueado = false;
            sptPlayer2.caminoBloqueado = false;
            BarrilPolvoraIzqRef.SetActive(false);
            BarrilPolvoraDerRef.SetActive(false);
            //if(Mathf.Round(alaIzquierda.transform.eulerAngles.y) != 280)
            //{ 
            //    alaIzquierda.transform.Rotate(new Vector3(0, 10 * -velApertura,0));
            //    Debug.Log(Mathf.Round(alaIzquierda.transform.eulerAngles.y));

            //    alaDerecha.transform.Rotate(new Vector3(0, 10 * velApertura, 0));
            //    Debug.Log(Mathf.Round(alaIzquierda.transform.eulerAngles.y));
            //}
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
