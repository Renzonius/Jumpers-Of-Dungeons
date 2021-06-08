using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    [Header("MOVIMIENTO")]
    #region Movimiento
    [SerializeField] bool _moverseAdelante;
    public bool moverseAdelante { get { return _moverseAdelante; } set { _moverseAdelante = value; } }

    [SerializeField] bool _moverseAtras;
    public bool moverseAtras { get { return _moverseAtras; } set { _moverseAtras = value; } }

    bool _moverseDerecha;
    public bool moverseDerecha { get { return _moverseDerecha; } set { _moverseDerecha = value; } }

    bool _moverseIzquierda;
    public bool moverseIzquierda { get { return _moverseIzquierda; } set { _moverseIzquierda = value; } }

    [SerializeField] bool _enSuelo;
    public bool enSuelo { get { return _enSuelo; } set { _enSuelo = value; } }

    [SerializeField] bool _sinMovimiento;
    public bool sinMovimiento { get { return _sinMovimiento; } set { _sinMovimiento = value; } }

    [SerializeField] bool _usarDesactivador;
    public bool usarDesactivador { get { return _usarDesactivador; } set { _usarDesactivador = value; } }

    [SerializeField] float _velocidadMovimiento;
    public float velocidadMovimiento { get { return _velocidadMovimiento; } set { _velocidadMovimiento = value; } }

    [SerializeField] float _tiempoEntreSaltos;
    public float tiempoEntreSaltos { get { return _tiempoEntreSaltos; } set { _tiempoEntreSaltos = value; } }

    [SerializeField] private bool _caminoBloqueado;
    public bool caminoBloqueado { get { return _caminoBloqueado; } set { _caminoBloqueado = value; } }

    public Vector3 distanciaPlataforma;
    public Vector3 posicionPlataforma;
    public Quaternion mirarAdelante;
    public Quaternion mirarAtras;

    [SerializeField] private bool _derrota;
    public bool derrota { get { return _derrota; } set { _derrota = value; } }

    [SerializeField] private bool _victoria;
    public bool victoria { get { return _victoria; } set { _victoria = value; } }

    public bool jugadorCortado;
    //public MathParabola caidaDañado;

    //public Vector3 coorInicio;
    //public Vector3 coorFinal;
    //float tiempoVuelo;
    public ParabolaController parabola;
    #endregion

    [Header("SPAWN")]
    #region SPAWN
    [SerializeField]  bool _activarSpawn;
    public bool activarSpawn { get { return _activarSpawn; } set { _activarSpawn = value; } }
    [SerializeField]  float _tiempoSpawn;
    public float tiempoSpawn { get { return _tiempoSpawn; } set { _tiempoSpawn = value; } }
    [SerializeField]  Vector3 _puntoSpawn;
    public Vector3 puntoSpawn { get { return _puntoSpawn; } set { _puntoSpawn = value; } }

    [SerializeField] bool _aplastado;
    public bool aplastado { get { return _aplastado; } set { _aplastado = value; } }

    Vector3 escala;
    Vector3 escalaNormal;

    [SerializeField] float _tiempoAplastado;
    public float tiempoAplastado { get { return _tiempoAplastado; } set { _tiempoAplastado = value; } }


    public GameObject cuerpo;
    #endregion

    [Header("INVENTARIO")]
    #region Inventario
    [SerializeField] private int _puntaje;
    public int puntaje { get { return _puntaje; } set { _puntaje = value; } }

    [SerializeField] private bool _llevaPolvora;
    public bool llevaPolvora { get { return _llevaPolvora; } set { _llevaPolvora = value; } }

    [SerializeField] private bool _cercaBarril;
    public bool cercaBarril { get { return _cercaBarril; } set { _cercaBarril = value; } }

    [SerializeField] private bool _cercaCañon;
    public bool cercaCañon { get { return _cercaCañon; } set { _cercaCañon = value; } }

    [SerializeField] Cañon sptCañon;

    #endregion


    [Header("GRAN SALON")]

    protected Rigidbody rigiRef;
    public bool corriendo;
    public float velocidadCorrer;
    public bool sigiloso;
    public float velocidadSigilo;
    public Vector3 posicion;




    void Start()
    {
        parabola = GetComponent<ParabolaController>();
        velocidadMovimiento = 20f;
        tiempoEntreSaltos = 0.5f;
        distanciaPlataforma = new Vector3(0, 0, 5f);
        tiempoSpawn = 3f;
        tiempoAplastado = 3f;
        escalaNormal = transform.localScale;
        mirarAdelante = transform.rotation;

        posicion = transform.position;
        rigiRef = GetComponent<Rigidbody>();
    }

    


    public abstract void ControlesDeInteraccion();
    public abstract void DireccionMovimiento();
    public abstract void DesactivarTrampas();


    public void VolverASpawnear()
    {
        tiempoSpawn -= Time.deltaTime;
        if (tiempoSpawn <= 0)
        {
            transform.position = new Vector3(-2f, 0, 0);
            cuerpo.SetActive(true);
            tiempoSpawn = 3f;
            activarSpawn = false;
            transform.position = puntoSpawn;
            sinMovimiento = false;

        }
    }

    public void MovimientoAdelante()
    {
        if (!jugadorCortado)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionPlataforma, velocidadMovimiento * Time.deltaTime);
            tiempoEntreSaltos -= Time.deltaTime;
        }

        if (transform.position == posicionPlataforma && tiempoEntreSaltos <= 0)
        {
            tiempoEntreSaltos = 0.5f;
            moverseAdelante = false;
        }
        if (transform.rotation == mirarAtras)
        {
            transform.Rotate(0, 180, 0);
            mirarAdelante = transform.rotation;
        }
    }
    public void MovimientoAtras()
    {
        transform.position = Vector3.MoveTowards(transform.position, posicionPlataforma, velocidadMovimiento * Time.deltaTime);
        tiempoEntreSaltos -= Time.deltaTime;

        if (transform.position == posicionPlataforma && tiempoEntreSaltos <= 0)
        {
            tiempoEntreSaltos = 0.5f;
            moverseAtras = false;
        }
        if(transform.rotation == mirarAdelante)
        {
            transform.Rotate(0, 180, 0);
            mirarAtras = transform.rotation;
        }
        
    }

    public void MovimientoCorrer()
    {
        posicion -= new Vector3(0f, 0f, velocidadCorrer * Time.deltaTime);
        transform.position = posicion;
    }

    public void MovimientoSigiloso()
    {
        posicion -= new Vector3(0f, 0f, velocidadSigilo * Time.deltaTime);
        transform.position = posicion;
    }



    public void MovimientoDerecha()
    {
        transform.position = Vector3.MoveTowards(transform.position, posicionPlataforma, velocidadMovimiento * Time.deltaTime);
        tiempoEntreSaltos -= Time.deltaTime;

        if (transform.position == posicionPlataforma && tiempoEntreSaltos <= 0)
        {
            tiempoEntreSaltos = 0.5f;
            moverseDerecha = false;
        }
    }

    public void MovimientoIzquierda()
    {
        transform.position = Vector3.MoveTowards(transform.position, distanciaPlataforma, velocidadMovimiento * Time.deltaTime);
        tiempoEntreSaltos -= Time.deltaTime;

        if (transform.position == distanciaPlataforma && tiempoEntreSaltos <= 0)
        {
            tiempoEntreSaltos = 0.5f;
            moverseIzquierda = false;
        }
    }

    public void CargarCañon()
    {
        sptCañon.cantPolvora++;
    }
    public void SumarPuntaje(int puntajeItem)
    {
        puntaje += puntajeItem;
    }
    public int PerderPuntaje(int puntaje)
    {
        puntaje = puntaje / 2;
        return puntaje;
    }

    public void Aplastamiento()
    {
        escala = transform.localScale;
        escala.y = 0.5f;
        transform.localScale = escala;
    }
    public void Estirar()
    {
        tiempoAplastado -= Time.deltaTime;
        if(tiempoAplastado <= 0f)
        {
            transform.localScale = escalaNormal;
            aplastado = false;
            tiempoAplastado = 3f;
            sinMovimiento = false;
        }
    }

    public void cortePendulo()
    {
        parabola.FollowParabola();
        jugadorCortado = false;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Suelo") || col.gameObject.CompareTag("SueloTrampa"))
        {
            enSuelo = true;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        string tipoTag = col.gameObject.tag;
        switch (tipoTag)
        {
            case "Oscuridad":
                activarSpawn = true;
                puntaje = PerderPuntaje(puntaje);
                Debug.Log(puntaje);
                cuerpo.SetActive(false);
                jugadorCortado = false;
                break;

            case "GranPorton":
                caminoBloqueado = true;
                break;

            case "BarrilPolvora":
                cercaBarril = true;
                break;

            case "Cañon":
                cercaCañon = true;
                sptCañon = col.gameObject.GetComponent<Cañon>();
                break;

            case "Prensadora":
                aplastado = true;
                Aplastamiento();
                puntaje = PerderPuntaje(puntaje);
                sinMovimiento = true;
                break;

            case "Parabola":
                parabola.ParabolaRoot = col.gameObject;
                break;

            case "Pendulo":
                parabola.generarRuta = true;
                jugadorCortado = true;
                sinMovimiento = true;
                break;

            case "Marca":
                corriendo = false;
                sigiloso = true;
                break;

            case "MarcaDragon":
                sigiloso = false;
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        string tipoTag = col.gameObject.tag;

        switch (tipoTag)
        {
            case "GranPorton":
                caminoBloqueado = false;
                break;

            case "BarrilPolvora":
                cercaBarril = false;
                break;

            case "Cañon":
                cercaCañon = false;
                break;

            default:
                break;
        }
    }
}   

