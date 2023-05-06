using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    public float velocidadMovimiento;

    public Rigidbody2D rB;

    public float potenciaSalto;
    public bool puedeSaltarDoble;

    private Animator anim;
    private SpriteRenderer sR;

    public bool estaEnSuelo;
    public Transform detectorSuelo;
    public LayerMask esSuelo;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sR = GetComponent<SpriteRenderer>();
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

        if(rB.velocity.x < 0)
        {
            sR.flipX = true;
        }else if (rB.velocity.x > 0) 
        {
            sR.flipX = false; 
        }

        anim.SetFloat("Movimiento", Mathf.Abs(rB.velocity.x));
        anim.SetBool("estaEnSuelo", estaEnSuelo);
        anim.SetBool("saltoDoble", puedeSaltarDoble);
    }
}
