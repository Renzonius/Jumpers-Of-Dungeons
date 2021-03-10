using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaulaObst : Obstaculo
{
    Vector3 posLocalObst;

    void Start()
    {
        posLocalObst = obstaculoRef.transform.localPosition;
        posInicialObst = posLocalObst;
        posBlequeoObst = new Vector3(posInicialObst.x, -1f, 0f);
        velMovimientoObst = 30f;
    }

    void FixedUpdate()
    {
        MovimientoDeJaula();
    }
}
