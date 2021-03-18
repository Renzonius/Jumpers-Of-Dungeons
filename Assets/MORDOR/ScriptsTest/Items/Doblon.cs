using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doblon : Tesoro
{
    public Quaternion asdasd;
    public override void Movimiento()
    {
        transform.RotateAround(transform.position, Vector3.down, velMovimiento * Time.deltaTime);

        Debug.Log("positivo");
        transform.Rotate(0, 0, -velMovimiento * Time.deltaTime);
    }
}
