using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SennalSpawnP1 : MonoBehaviour
{
    Spawnear sptSpawnP1;
    public TextMesh marcadorTiempoSpawn;
    void Start()
    {
        sptSpawnP1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Spawnear>();
        marcadorTiempoSpawn = transform.GetChild(0).gameObject.GetComponent<TextMesh>();
    }

    void Update()
    {
        marcadorTiempoSpawn.text = (Mathf.Round(sptSpawnP1.tiempoSpawn)).ToString();
        Destroy(gameObject, 2f);
    }
}
