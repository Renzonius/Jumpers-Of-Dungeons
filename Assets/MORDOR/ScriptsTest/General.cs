using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour
{
    [Header ("Players")]
    #region Players
    public GameObject playerUnoRef;
    public ControlPlayerUno sptPlayerUno;
    public GameObject playerDosRef;
    public ControlPlayerDos sptPlayerDos;
    #endregion
    void Start()
    {
        playerUnoRef = GameObject.FindGameObjectWithTag("Player");
        sptPlayerUno = playerUnoRef.GetComponent<ControlPlayerUno>();

        playerDosRef = GameObject.FindGameObjectWithTag("Player2");
        sptPlayerDos = playerDosRef.GetComponent<ControlPlayerDos>();
    }

    private void FixedUpdate()
    {

    }

}
