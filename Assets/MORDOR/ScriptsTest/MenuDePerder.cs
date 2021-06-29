using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDePerder : MonoBehaviour
{
    public static bool pausado = false;

    public GameObject menuPausa;

    public Perder sptPlayerUno;
    public Perder sptPlayerDos;

    public GameObject MarcadorPuntajeCanvas;

    public Scene nombreEscena;
    private void Start()
    {
        sptPlayerUno = GameObject.FindGameObjectWithTag("Player").GetComponent<Perder>();
        sptPlayerDos = GameObject.FindGameObjectWithTag("Player2").GetComponent<Perder>();

        MarcadorPuntajeCanvas = GameObject.FindGameObjectWithTag("HUDPuntaje");

        nombreEscena = transform.parent.gameObject.scene;
    }



    void FixedUpdate()
    {
        if (sptPlayerUno.perder || sptPlayerDos.perder)
        {
            StartCoroutine(ActivarMenu());
        }

    }


    IEnumerator ActivarMenu()
    {
        yield return new WaitForSeconds(3f);
        MarcadorPuntajeCanvas.SetActive(false);
        Pausar();
    }


    void Pausar()
    {
        menuPausa.SetActive(true);
        pausado = true;
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
