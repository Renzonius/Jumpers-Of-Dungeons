using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Guardar : MonoBehaviour
{
    public Text texto;

    string nombre;

    public GameObject alertaFaltaNombre;

    public Puntaje sptPlayerUno;
    public Puntaje sptPlayerDos;


    private void Start()
    {
        sptPlayerUno = GameObject.FindGameObjectWithTag("Player").GetComponent<Puntaje>();
        sptPlayerDos = GameObject.FindGameObjectWithTag("Player2").GetComponent<Puntaje>();
        alertaFaltaNombre = transform.GetChild(4).gameObject;
    }

    public void GuardarPuntaje()
    {
        if (texto.text != string.Empty && texto.text != " " && texto.text != "  " && texto.text != "   ")
        {
            nombre = texto.text;
            nombre = nombre.ToUpper();
            int puntajeTotal = sptPlayerUno.puntaje + sptPlayerDos.puntaje;
            PlayerPrefs.SetInt("Puntaje", puntajeTotal);
            PlayerPrefs.SetString("Nombre", nombre);
            SceneManager.LoadScene("Titulo");
            alertaFaltaNombre.SetActive(false);
        }
        else
        {
            alertaFaltaNombre.SetActive(true);
        }
    }

}
