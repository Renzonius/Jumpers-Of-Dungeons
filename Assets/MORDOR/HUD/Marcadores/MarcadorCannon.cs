using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarcadorCannon : MonoBehaviour
{
    public Cañon sptCannon;
    public TextMesh marcadorPolvora;
    SpriteRenderer sennal;
    void Start()
    {
        sptCannon = transform.GetComponentInParent<Cañon>();
        marcadorPolvora = transform.GetChild(0).gameObject.GetComponent<TextMesh>();
        sennal = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        marcadorPolvora.text = sptCannon.cantPolvora.ToString();
        OcultarSennal();
    }

    void OcultarSennal()
    {
        if (sptCannon.cantPolvora >= sptCannon.polvoraNecesaria)
        {
            sennal.color = new Color(255, 255, 255, 0);
            marcadorPolvora.color = new Color(255, 255, 255, 0);
        }
    }

}
