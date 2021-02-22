using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampaMuro : MonoBehaviour
{
    public GameObject pared;
    Vector3 posPared;
    Vector3 posBloqueo = new Vector3(0, 0, 7.5f);
    public float velDesplazamiento;
    public bool paredActivada;
    
    void Start()
    {
        posPared = pared.transform.position;
    }

    void Update()
    {
        if (paredActivada)
            pared.transform.position = Vector3.MoveTowards(pared.transform.position, posBloqueo, velDesplazamiento * Time.deltaTime);
        else
            pared.transform.position = Vector3.MoveTowards(pared.transform.position, new Vector3(0, -8f, 7.5f), velDesplazamiento * Time.deltaTime);

    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            paredActivada = true;
            Debug.Log("hola");
            //pared.transform.position = Vector3.MoveTowards(pared.transform.position, posBloqueo, velDesplazamiento * Time.deltaTime);
        }

    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            paredActivada = false;
            Debug.Log("holaaa");
            //pared.transform.position = Vector3.MoveTowards(pared.transform.position, new Vector3(0,-2,0), velDesplazamiento * Time.deltaTime);
        }
    }

    
}
