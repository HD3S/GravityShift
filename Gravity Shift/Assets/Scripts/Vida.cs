using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    public Image[] puntosVida;

    private int vida;

    private void Start()
    {
        vida = ControlVidaJugador.instance.vidaActual;
    }

    private void Update()
    {
        vida = ControlVidaJugador.instance.vidaActual;
        RellenadorVida();
    }

    void RellenadorVida() 
    {
        for(int i = 0;  i < puntosVida.Length; i++)
        {
            puntosVida[i].enabled = !MostrarPuntosVida(vida, i);
        }
    }

    bool MostrarPuntosVida(int ivida, int pointnumber)
    {
        return ((pointnumber * 10) >= ivida);
    }

    /*public void Curar(int puntosCura)
    {
        if(vida < vidaMaxima)
        {
            vida += puntosCura;
        }
    }*/
}
