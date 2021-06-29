using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulasDoblenes : MonoBehaviour
{
    void FixedUpdate()
    {
        Destroy(gameObject, 3f);
    }
}
