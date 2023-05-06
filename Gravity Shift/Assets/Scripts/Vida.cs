using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    public Image[] puntosVida;

    public float vida, vidaMaxima = 100;

    private void Start()
    {
        vida = vidaMaxima;
    }

    private void Update()
    {
        if (vida > vidaMaxima)
        {
             vida = vidaMaxima;
        }
        RellenadorVida();
    }

    void RellenadorVida() 
    {
        for(int i = 0;  i < puntosVida.Length; i++)
        {
            puntosVida[i].enabled = !MostrarPuntosVida(vida, i);
        }
    }

    bool MostrarPuntosVida(float ivida, int pointnumber)
    {
        return ((pointnumber * 10) >= ivida);
    }

    public void Dagnar(float puntosDagno)
    { 
        if(vida > 0)
        {
            vida -= puntosDagno;
        }
    }
    public void Curar(float puntosCura)
    {
        if(vida < vidaMaxima)
        {
            vida += puntosCura;
        }
    }
}
