using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaulaObst : Obstaculo
{
    Vector3 posLocalObst;
    public float tiempoActivado;

    void Start()
    {
        posLocalObst = obstaculoRef.transform.localPosition;
        posInicialObst = posLocalObst;
        posBlequeoObst = new Vector3(posInicialObst.x, -1f, 0f);
        velMovimientoObst = 30f;
    }

    void FixedUpdate()
    {
        Movimiento();
        TiempoActivo();

    }

    public override void Movimiento()
    {
        if (obstActivado)
        {
            obstaculoRef.transform.localPosition = Vector3.MoveTowards(obstaculoRef.transform.localPosition, posBlequeoObst, velMovimientoObst * Time.deltaTime);
            tiempoActivado -= Time.deltaTime;
        }
        else
        {
            obstaculoRef.transform.localPosition = Vector3.MoveTowards(obstaculoRef.transform.localPosition, posInicialObst, velMovimientoObst * Time.deltaTime);
            tiempoActivado = 5f;
        }
    }

    public void TiempoActivo()
    {
        if (tiempoActivado <= 0)
        {
            obstActivado = false;
        }
    }
}
