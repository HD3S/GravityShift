using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.XR;

public class ControlEnemigo : MonoBehaviour
{
    public float velocidadMovimiento;

    public GameObject limiteIzq;
    public GameObject limiteDcha;

    private bool movimientoDcha;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    public float tiempoMovimiento, tiempoEspera;
    private float contadorMovimiento, contadorEspera;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        movimientoDcha = false;
        contadorMovimiento = tiempoMovimiento;

    }

    // Update is called once per frame
    void Update()
    {
        if (contadorMovimiento > 0)
        {
            anim.SetBool("estaCaminando", true);
            contadorMovimiento -= Time.deltaTime;

            if (movimientoDcha)
            {
                sr.flipX = true;
                rb.velocity = new Vector2(velocidadMovimiento, transform.position.y);

                if (transform.position.x >= limiteDcha.transform.position.x)
                {
                    movimientoDcha = false;
                }
            }
            else
            {
                sr.flipX = false;
                rb.velocity = new Vector2(-velocidadMovimiento, transform.position.y);

                if (transform.position.x <= limiteIzq.transform.position.x)
                {
                    movimientoDcha = true;
                }
            }

            if (contadorMovimiento <= 0)
                contadorEspera = Random.Range(tiempoEspera * 0.75f, tiempoEspera * 1.25f);
        }
        else if(contadorEspera > 0)
        {
            anim.SetBool("estaCaminando", false);
            contadorEspera -= Time.deltaTime;
            rb.velocity = new Vector2(0f, transform.position.y);

            if (contadorEspera <= 0)
                contadorMovimiento = Random.Range(tiempoMovimiento * 0.75f, tiempoMovimiento * 1.25f);
        }
    }
}
