using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cañon : MonoBehaviour
{
    public int cantPolvora;
    public int polvoraNecesaria;
    public GranPorton sptPorton;

    void FixedUpdate()
    {
        Disparar();
    }

    public void Disparar()
    {
        if (cantPolvora >= polvoraNecesaria)
        {
            sptPorton.portonDestruido = true;
            cantPolvora = 0;
        }
    }
}
