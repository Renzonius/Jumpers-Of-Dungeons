using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntajeP1 : MonoBehaviour
{
    public Text texto;
    public ControlPlayerUno sptPlayerUno;
    public ControlPlayerDos sptPlayerDos;

    void Update()
    {
        texto.text = sptPlayerUno.puntaje.ToString();
        GuardarPuntaje();
    }

    void GuardarPuntaje()
    {
        if (sptPlayerUno.derrota || sptPlayerDos.derrota)
        {
            PlayerPrefs.SetInt("PuntajeP1", sptPlayerUno.puntaje);
        }

        if (sptPlayerUno.victoria || sptPlayerDos.victoria)
        {
            PlayerPrefs.SetInt("PuntajeP1", sptPlayerUno.puntaje);
        }
    }
}
