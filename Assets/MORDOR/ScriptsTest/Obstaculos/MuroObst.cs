﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuroObst : Obstaculo
{
    Vector3 posLocalObst;

    void Start()
    {
        posLocalObst = obstaculoRef.transform.localPosition;
        posInicialObst = posLocalObst;
        posBlequeoObst = new Vector3(posInicialObst.x, -1f, 0f);
        velMovimientoObst = 50f;
    }

    void FixedUpdate()
    {
        Movimiento();
    }

    public override void Movimiento()
    {
        if (obstActivado)
            obstaculoRef.transform.localPosition = Vector3.MoveTowards(obstaculoRef.transform.localPosition, posBlequeoObst, velMovimientoObst * Time.deltaTime);
        else
            obstaculoRef.transform.localPosition = Vector3.MoveTowards(obstaculoRef.transform.localPosition, posInicialObst, velMovimientoObst * Time.deltaTime);
    }
}