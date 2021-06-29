using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre_item : MonoBehaviour
{
    public GameObject cofreObj;
    public Vector3 cofrePos;
    public Vector3 maxAltura;
    public Vector3 minAltura;
    public float velocidad;
    public bool sube;
    public GameObject tesoro;
    bool tesoroTomado;
    Rigidbody cofreRigidRef;

    public Animation anim;
    public Animator animator;
    

    void Start()
    {
        cofreRigidRef = gameObject.GetComponent<Rigidbody>();
        cofrePos = cofreObj.transform.localPosition;
        //maxAltura = new Vector3(0, 0.5f, 0);
        minAltura = new Vector3(0, 0, 0);
        //velocidad = 25f;
    }

    void FixedUpdate()
    {
        if (!tesoroTomado)
            AnimacionCofre();


    }

    void AnimacionCofre()
    {
        if (cofreObj.transform.localPosition.y <= minAltura.y)
            sube = true;
        else if (cofreObj.transform.localPosition.y >= maxAltura.y)
            sube = false;

        if (sube)
        {
            cofrePos = Vector3.MoveTowards(cofrePos, maxAltura, velocidad * Time.deltaTime);
            cofreObj.transform.localPosition = cofrePos;
        }
        else if (!sube)
        {
            cofrePos = Vector3.MoveTowards(cofrePos, minAltura, velocidad * Time.deltaTime);
            cofreObj.transform.localPosition = cofrePos;

        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "Player2")
        {
            tesoroTomado = true;
            tesoro.SetActive(false);
            animator.enabled = true; //activa la toracion para caer
            anim.Play("CerrarCofre");
        }
        else if (col.gameObject.tag == "Oscuridad")
        {
            Destroy(gameObject);
        }
    }
}
