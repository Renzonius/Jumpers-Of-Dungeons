using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstaculo : MonoBehaviour
{
    public GameObject obstaculoRef;
    public GameObject activadorRef;
    public Vector3 posInicialObst;
    public Vector3 posBlequeoObst;

    [SerializeField] private bool _obstActivado;
    public bool obstActivado { get { return _obstActivado; } set { _obstActivado = value; } }

    [SerializeField] private float _velMovimientoObst;
    public float velMovimientoObst { get { return _velMovimientoObst; } set { _velMovimientoObst = value; } }

    public abstract void Movimiento();


}
