using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBombardero : MonoBehaviour
{
    public float velocidadMovimiento;
    private int numBombas;

    public GameObject bomba;
    public Transform posicionBomba;

    public GameObject limiteIzq;
    public GameObject limiteDcha;

    private bool movimientoDcha;

    public Rigidbody2D rb;
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
            contadorMovimiento -= Time.deltaTime;
            numBombas = 1;

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
        else if (contadorEspera > 0)
        {
            if(numBombas > 0)
            {
                numBombas--;
                anim.SetTrigger("soltarBomba");
                Instantiate(bomba, posicionBomba.position, Quaternion.identity);

            }
            
            contadorEspera -= Time.deltaTime;
            rb.velocity = new Vector2(0f, transform.position.y);

            if (contadorEspera <= 0)
                contadorMovimiento = Random.Range(tiempoMovimiento * 0.75f, tiempoMovimiento * 1.25f);
        }
    }
}
