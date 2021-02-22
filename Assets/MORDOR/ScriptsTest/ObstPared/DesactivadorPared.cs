using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivadorPared : MonoBehaviour
{
    public GameObject activador;
    TrampaPared scriptPared;
    [SerializeField]
    private bool _descativadorPresionado;
    public bool descativadorPresionado
    {
        get { return _descativadorPresionado; }
        set { _descativadorPresionado = value; }
    }

    void Start()
    {
        scriptPared = activador.GetComponent<TrampaPared>();
    }

    void Update()
    {
        
    }

    //private void OnTriggerEnter(Collider col)
    //{
    //    if (scriptPared.paredActivada && (col.gameObject.tag == "Player" || col.gameObject.tag == "Player2"))
    //    {
    //        scriptPared.paredActivada = false;
    //        descativadorPresionado = true;
    //        Debug.Log("hola");
    //    }
    //}
    private void OnTriggerStay(Collider col)
    {
        if (scriptPared.paredActivada && col.gameObject.tag == "Player" || col.gameObject.tag == "Player2")
        {
            scriptPared.paredActivada = false;
            descativadorPresionado = true;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if(scriptPared.paredActivada && col.gameObject.tag == "Player" || col.gameObject.tag == "Player2")
        {
            scriptPared.paredActivada = false;
            descativadorPresionado = false;
        }
    }
}
