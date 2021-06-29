using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnP2 : MonoBehaviour
{
    public GameObject spawnPlayer2;
    public Text contador;
    public ControlPlayerDos sptPlayerDos;

    void Update()
    {
        if (sptPlayerDos.activarSpawn)
        {
            Spawn();
        }
        else
        {
            spawnPlayer2.SetActive(false);
        }
    }

    void Spawn()
    {
        spawnPlayer2.SetActive(true);
        contador.text = sptPlayerDos.tiempoSpawn.ToString("0");
    }
}
