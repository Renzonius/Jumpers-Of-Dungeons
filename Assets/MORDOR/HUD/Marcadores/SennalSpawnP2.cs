using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SennalSpawnP2 : MonoBehaviour
{
    public Spawnear sptSpawnP2;
    public TextMesh marcadorTiempoSpawn;
    void Start()
    {
        sptSpawnP2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Spawnear>();
        marcadorTiempoSpawn = transform.GetChild(0).gameObject.GetComponent<TextMesh>();
    }

    void Update()
    {
        marcadorTiempoSpawn.text = (Mathf.Round(sptSpawnP2.tiempoSpawn)).ToString();
        Destroy(gameObject, 2f);
    }
}
