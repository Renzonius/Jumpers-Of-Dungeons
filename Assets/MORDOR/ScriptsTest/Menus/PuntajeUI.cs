using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntajeUI : MonoBehaviour
{
    public Text contador;
    public ControlPlayerUno sptPlayerUno;
    public ControlPlayerDos sptPlayerDos;

    void Update()
    {
        contador.text = (sptPlayerUno.puntaje + sptPlayerDos.puntaje).ToString();
    }
}
