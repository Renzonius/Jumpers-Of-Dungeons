using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perder : MonoBehaviour
{
    public bool perder;

    MovimientoGeneral sptMovimiento;

    public Material[] materialCuerpo;

    public Color colorOriginal;
    public Color colorQuemado;

    Animator animator;

    void Start()
    {
        materialCuerpo = transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>().materials;
        sptMovimiento = GetComponent<MovimientoGeneral>();
        colorOriginal = materialCuerpo[0].color;
        colorQuemado = new Color(0, 0, 0);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (perder)
        {
            materialCuerpo[0].color = colorQuemado;
        }
        else
            materialCuerpo[0].color = colorOriginal;

    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "BolaFuego")
        {
            perder = true;
            sptMovimiento.sinMovimiento = true;
            animator.Play("Morir");
        }
    }
}
