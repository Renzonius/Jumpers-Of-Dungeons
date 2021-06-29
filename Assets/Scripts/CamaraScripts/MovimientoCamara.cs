using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public float velocidadSmooth;
    public Vector3 posCamara;
    public Vector3 posSmooth;
    public Camera camRef;
    public GameObject objFocoRef;
    public Vector3 offset;
    
    void Start()
    {
        posCamara = gameObject.transform.position;

    }

    void FixedUpdate()
    {
        //posCamara.z += velocidad * Time.deltaTime;
        //gameObject.transform.position = posCamara;
        posCamara = objFocoRef.transform.position + offset;
        posSmooth = Vector3.Lerp(transform.position, posCamara, velocidadSmooth);
        transform.position = posSmooth;

        camRef.transform.LookAt(objFocoRef.transform);
        //camRef.transform.LookAt(objFocoRef.transform);

        //Enfocar(objFocoRef);

    }

}
