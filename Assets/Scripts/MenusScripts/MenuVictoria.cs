using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuVictoria : MonoBehaviour
{
    public GameObject menu;

    public Ganar sptPlayerUno;
    public Ganar sptPlayerDos;

    public GameObject MarcadorPuntajeCanvas;

    public Scene nombreEscena;
    private void Start()
    {
        sptPlayerUno = GameObject.FindGameObjectWithTag("Player").GetComponent<Ganar>();
        sptPlayerDos = GameObject.FindGameObjectWithTag("Player2").GetComponent<Ganar>();

        MarcadorPuntajeCanvas = GameObject.FindGameObjectWithTag("HUDPuntaje");

        nombreEscena = transform.parent.gameObject.scene;
    }



    void FixedUpdate()
    {
        if (sptPlayerUno.portalJugador && sptPlayerDos.portalJugador)
        {
            StartCoroutine(ActivarMenu());
        }

    }


    IEnumerator ActivarMenu()
    {
        yield return new WaitForSeconds(2f);
        MarcadorPuntajeCanvas.SetActive(false);
        menu.SetActive(true);
    }



    public void Menu()
    {
        SceneManager.LoadScene("Titulo");
    }


    public void Resetear()
    {
        //SceneManager.LoadScene(nombreEscena.name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
