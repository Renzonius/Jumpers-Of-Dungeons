using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuegoPlataforma : MonoBehaviour
{
    public ParticleSystem fuegoRef;
    public bool activarFuego;
    void Start()
    {
        fuegoRef.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        StartCoroutine(FuegoEncendido());
        StartCoroutine(RecargarFuego());
        //fuegoRef.Play();
    }

    IEnumerator FuegoEncendido()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Fuegooo");
        fuegoRef.Play();
    }

    IEnumerator RecargarFuego()
    {
        yield return new WaitForSeconds(7f);
        Debug.Log("DetenerFuego");
        fuegoRef.Stop();
        StopAllCoroutines();
    }
}
