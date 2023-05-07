using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;
    // Start is called before the first frame update
    
    public void SumarPuntos(int puntosSumar)
    {
        puntosTotales += puntosSumar;
    }
}
