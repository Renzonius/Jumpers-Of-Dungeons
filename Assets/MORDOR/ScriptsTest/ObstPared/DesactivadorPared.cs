using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivadorPared : MonoBehaviour
{
    public GameObject activador;
    TrampaPared scriptPared;
    [SerializeField] private bool _descativadorPresionado;
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


    private void OnTriggerStay(Collider col)
    {
        if (scriptPared.paredActivada && (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Player2")))
        {
            scriptPared.paredActivada = false;
            descativadorPresionado = true;
            Debug.Log("Pared desactivada por: " + col.gameObject.name);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if(scriptPared.paredActivada && col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Player2"))
        {
            scriptPared.paredActivada = false;
            descativadorPresionado = false;
        }
    }
}
