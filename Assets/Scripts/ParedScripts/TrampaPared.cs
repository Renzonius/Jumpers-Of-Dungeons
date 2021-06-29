using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaPared : MonoBehaviour
{
    public GameObject pared;
    Vector3 posPared;
    //Vector3 posBloqueo = new Vector3 (0, 0, 7.5f);
    Vector3 posBloqueo;
    public float velDesplazamiento;
    public GameObject desactivador;
    DesactivadorPared scriptDesactivador;
    [SerializeField] private bool _paredActivada;
    public bool paredActivada {
        get { return _paredActivada; } 
        set { _paredActivada = value; } 
    }

    void Start()
    {
        scriptDesactivador = desactivador.GetComponent<DesactivadorPared>();
        posPared = pared.transform.localPosition;
        //posBloqueo = new Vector3(transform.localPosition.x, 0f, 7.5f);
        posBloqueo = new Vector3(transform.localPosition.x, -1f, 0);
    }

    void FixedUpdate()
    {
        if (paredActivada)
            pared.transform.localPosition = Vector3.MoveTowards(pared.transform.localPosition, posBloqueo, velDesplazamiento * Time.deltaTime);
        else 
            pared.transform.localPosition = Vector3.MoveTowards(pared.transform.localPosition, posPared, velDesplazamiento * Time.deltaTime);

    }

    private void OnTriggerStay(Collider col)
    {
        if (!scriptDesactivador.descativadorPresionado && (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Player2")))
        {
                paredActivada = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if(scriptDesactivador.descativadorPresionado || col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Player2"))
        {
            paredActivada = false;
        }
    }

}
