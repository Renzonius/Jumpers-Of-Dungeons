using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntajeP2 : MonoBehaviour
{
    public Text texto;
    public ControlPlayerUno sptPlayerUno;
    public ControlPlayerDos sptPlayerDos;

    void Update()
    {
        texto.text = sptPlayerDos.puntaje.ToString();
        GuardarPuntaje();
    }

    void GuardarPuntaje()
    {
        if (sptPlayerUno.derrota || sptPlayerDos.derrota)
        {
            PlayerPrefs.SetInt("PuntajeP2", sptPlayerDos.puntaje);
        }

        if (sptPlayerUno.victoria || sptPlayerDos.victoria)
        {
            PlayerPrefs.SetInt("PuntajeP2", sptPlayerDos.puntaje);
        }
    }
}
