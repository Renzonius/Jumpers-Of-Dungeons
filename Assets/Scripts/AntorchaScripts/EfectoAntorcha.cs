using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoAntorcha : MonoBehaviour
{


    [SerializeField] private float _intensidad;
    public float intensidad { 
        get { return _intensidad; }
        set { _intensidad = value; }
    }

    [SerializeField] private float _minIntencidad;
    public float minIntencidad { 
        get { return _minIntencidad; }
        set { _intensidad = value; }
    }
    [SerializeField] private float _maxIntencidad;
    public float maxIntencidad { 
        get { return _maxIntencidad; }
        set { _maxIntencidad = value; } 
    }
    [SerializeField] private float _velocidad;
    public float velocidad {
        get { return _velocidad; } 
        set { _velocidad = value; } 
    }
    [SerializeField] private bool _destelloCambia;
    public bool destelloCambia { 
        get { return _destelloCambia; }
        set { _destelloCambia = value; }
    }


    void FixedUpdate()
    {
        EfectoDestello();
    }

    void EfectoDestello()
    {
        this.GetComponent<Light>().intensity = intensidad;

        //aumenta el destello
        if (intensidad <= minIntencidad)
        {
            destelloCambia = false;  
        }
        //disminuye el destello
        else if(intensidad >= maxIntencidad)
        {
            destelloCambia = true;
        }
        
        //efecto ping pong
        if(destelloCambia == true)
        {
            intensidad -= velocidad * Time.deltaTime;
        }
        else
        {
            intensidad += velocidad * Time.deltaTime;
        }
    }
}
