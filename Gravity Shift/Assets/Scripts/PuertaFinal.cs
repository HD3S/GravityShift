using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaFinal : MonoBehaviour
{
    public GameManager gamemanager;
    public GameObject puerta;
    [SerializeField] private AudioClip resolverPuzzle;
    [SerializeField] private AudioClip falloPuzzle;
    private bool puertaActiva = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && gamemanager.LlavesTotales==3 && puertaActiva)
        {
            ControladorSonidos.instance.EjecutarSonido(resolverPuzzle);
            Destroy(puerta);
            puertaActiva = false;
        }
        if(collision.CompareTag("Player") && gamemanager.LlavesTotales != 3 && puertaActiva)
        {
            ControladorSonidos.instance.EjecutarSonido(falloPuzzle);
        }
    }

}
