using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text puntaje;
    public int max;

    void Start()
    {
        max = (PlayerPrefs.GetInt("PuntajeP1", 0) + PlayerPrefs.GetInt("PuntajeP2", 0));
        puntaje.text = max.ToString();
    }

    void Update()
    {
        int sum = (PlayerPrefs.GetInt("PuntajeP1", 0) + PlayerPrefs.GetInt("PuntajeP2", 0));
        if (sum > max)
        {
            max = sum;
            puntaje.text = max.ToString();
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        max = 0;
    }

}
