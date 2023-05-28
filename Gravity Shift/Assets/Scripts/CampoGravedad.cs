using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampoGravedad : MonoBehaviour
{
    private bool entra = true;
    public Rigidbody2D ikariGravedad;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && entra)
        {
            ControlJugador.instance.potenciaSalto = .5f;
            ikariGravedad.gravityScale = .05f;
            entra = false;
        }
        else if(collision.gameObject.CompareTag("Player") && !entra)
        {
            ControlJugador.instance.potenciaSalto = 1.75f;
            ikariGravedad.gravityScale = .5f;
            entra = true;
        }
    }
}
