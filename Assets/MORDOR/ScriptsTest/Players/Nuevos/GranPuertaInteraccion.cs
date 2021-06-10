using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranPuertaInteraccion : MonoBehaviour
{
    bool cercaBarril;
    bool llevaPolvora;
    bool cercaCannon;

    public string teclaParaInteractuar;

    Cañon sptCannon;

    public Animator animator;
    public void TeclaCargarCannon()
    {
        if (Input.GetKeyDown(teclaParaInteractuar) && cercaCannon && llevaPolvora)
        {
            animator.SetTrigger("accion");
            CargarCannon();
            llevaPolvora = false;
        }


    }

    public void TeclaTomarPolvora()
    {
        if (Input.GetKeyDown(teclaParaInteractuar) && cercaBarril)
        {
            llevaPolvora = true;
            animator.SetTrigger("accion");
        }
    }

    void CargarCannon()
    {
        sptCannon.cantPolvora++;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        TeclaTomarPolvora();
        TeclaCargarCannon();
    }

    private void OnTriggerEnter(Collider col)
    {
        string tipoTag = col.gameObject.tag;
        switch (tipoTag)
        {
            case "BarrilPolvora":
                cercaBarril = true;
                break;
            case "Cañon":
                cercaCannon = true;
                sptCannon = col.gameObject.GetComponent<Cañon>();
                break;
            default:
                break;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        string tipoTag = col.gameObject.tag;
        switch (tipoTag)
        {
            case "BarrilPolvora":
                cercaBarril = false;
                break;
            case "Cañon":
                cercaCannon = false;
                sptCannon = col.gameObject.GetComponent<Cañon>();
                break;
            default:
                break;
        }
    }
}
