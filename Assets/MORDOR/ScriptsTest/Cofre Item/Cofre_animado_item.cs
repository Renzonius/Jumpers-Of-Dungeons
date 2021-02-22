using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre_animado_item : MonoBehaviour
{
    public Animation anim;
    void Start()
    {
        anim.Play("CerrarCofre");
    }

    void Update()
    {
        
    }
}
