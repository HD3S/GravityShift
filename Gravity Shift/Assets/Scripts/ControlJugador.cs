using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    public float velocidadMovimiento;
    public Rigidbody2D rB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rB.velocity = new Vector2(velocidadMovimiento * Input.GetAxis("Horizontal"), rB.velocity.y);
    }
}
