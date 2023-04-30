using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    public float velocidadMovimiento;

    public Rigidbody2D rB;

    public float potenciaSalto;
    public bool puedeSaltarDoble;

    public bool estaEnSuelo;
    public Transform detectorSuelo;
    public LayerMask esSuelo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rB.velocity = new Vector2(velocidadMovimiento * Input.GetAxisRaw("Horizontal"), rB.velocity.y);

        estaEnSuelo = Physics2D.OverlapCircle(detectorSuelo.position, .2f, esSuelo);

        if (estaEnSuelo)
        {
            puedeSaltarDoble = true;
        }

        if (Input.GetButtonDown("Jump")) 
        {
            if (estaEnSuelo)
            {
                rB.velocity = new Vector2(rB.velocity.x, potenciaSalto);
            }
            else
            {
                if (puedeSaltarDoble)
                {
                    rB.velocity = new Vector2(rB.velocity.x, potenciaSalto);
                    puedeSaltarDoble = false;
                }
            }
        }
    }
}
