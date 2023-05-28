using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bateria : MonoBehaviour
{
    [SerializeField] private AudioClip heal;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ControlVidaJugador.instance.vidaActual=100;
            ControladorSonidos.instance.EjecutarSonido(heal);
            Destroy(this.gameObject);
        }
    }
}
