﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDerrota : MonoBehaviour
{
    public static bool pausado = false;

    public GameObject menuPausa;

    public ControlPlayerUno sptPlayerUno;
    public ControlPlayerDos sptPlayerDos;

    void Update()
    {
        if (sptPlayerUno.derrota || sptPlayerDos.derrota)
        {
            Pausar();
        }
    }

    void Pausar()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0f;
        pausado = true;
    }

    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Salir()
    {
        Debug.Log("Saliendo...");
        Application.Quit();
    }
}