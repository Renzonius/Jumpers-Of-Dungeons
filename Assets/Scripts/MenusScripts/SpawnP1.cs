using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnP1 : MonoBehaviour
{
    public GameObject spawnPlayer1;
    public Text contador;
    public ControlPlayerUno sptPlayerUno;

    void Update()
    {
        if (sptPlayerUno.activarSpawn)
        {
            Spawn();
        }
        else
        {
            spawnPlayer1.SetActive(false);
        }
    }

    void Spawn()
    {
        spawnPlayer1.SetActive(true);
        contador.text = sptPlayerUno.tiempoSpawn.ToString("0");
    }
}