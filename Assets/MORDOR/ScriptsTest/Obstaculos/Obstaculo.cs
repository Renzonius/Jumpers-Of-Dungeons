using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public GameObject obstaculoRef;
    public GameObject activadorRef;

    [SerializeField] private bool _obstActivado;
    public bool obstActivado { get { return _obstActivado; } set { _obstActivado = value; } }

    public Vector3 posInicialObst;
    public Vector3 posBlequeoObst;

    [SerializeField] private float _velMovimientoObst;
    public float velMovimientoObst { get { return _velMovimientoObst; } set { _velMovimientoObst = value; } }

    public void MovimientoDeJaula()
    {
        if (obstActivado)
            obstaculoRef.transform.localPosition = Vector3.MoveTowards(obstaculoRef.transform.localPosition, posBlequeoObst, velMovimientoObst * Time.deltaTime);
        else
            obstaculoRef.transform.localPosition = Vector3.MoveTowards(obstaculoRef.transform.localPosition, posInicialObst, velMovimientoObst * Time.deltaTime);
    }
}
