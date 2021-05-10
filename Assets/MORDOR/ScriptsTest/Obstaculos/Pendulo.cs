using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulo : MonoBehaviour
{

    public float tiempo;
    public float velocidad;
    public int fase;


    void FixedUpdate()
    {
        MovimientoPendulo();
    }

    public void MovimientoPendulo()
    {
        tiempo += Time.deltaTime;

        if (tiempo > 1f)
        {
            fase++;
            fase %= 4;
            tiempo = 0f;
        }

        switch (fase)
        {
            case 0:
                transform.Rotate(0f, 0f, velocidad * (1 - tiempo));
                break;

            case 1:
                transform.Rotate(0f, 0f, -velocidad * tiempo);
                break;

            case 2:
                transform.Rotate(0f, 0f, -velocidad * (1 - tiempo));
                break;

            case 3:
                transform.Rotate(0f, 0f, velocidad * tiempo);
                break;

            default:
                break;
        }
    }
}
