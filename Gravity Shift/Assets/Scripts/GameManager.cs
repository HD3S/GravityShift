using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;

    public float tiempoParaRespawnear;

    public static GameManager instance;
    // Start is called before the first frame update

    public void Awake()
    {
        instance = this; 
    }
    public void SumarPuntos(int puntosSumar)
    {
        puntosTotales += puntosSumar;
    }

    public void RespawnearJugador()
    {
        StartCoroutine(RespawnCo());
    }

    IEnumerator RespawnCo()
    {
        yield return new WaitForSeconds(0.5f);
        ControlJugador.instance.gameObject.SetActive(false);
        yield return new WaitForSeconds(tiempoParaRespawnear);
        ControlJugador.instance.gameObject.SetActive(true);
        ControlJugador.instance.transform.position = ControladorCheck.Instance.puntoRespawn;
        
    }
}
