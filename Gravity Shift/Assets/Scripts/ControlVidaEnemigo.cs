using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVidaEnemigo : MonoBehaviour
{
    public static ControlVidaEnemigo instance;

    public float vida;
    //una variable para diferenciar los 3 diferentes enemigos que tenemos
    //para cambiar el tipo de danio que hacen
    public int tipoEnemigo;

    private Animator anim;
    private Rigidbody2D rb;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        vida = 100;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(vida <= 0)
        {
            ManejadorDano(0);
        }
    }

    public void ManejadorDano(float dano)
    {
        if(vida > 0)
        {
            switch (tipoEnemigo)
            {
                case 0:
                    vida -= dano;
                    break;
                case 1:
                    vida -= dano;
                    //add animation
                    break;
                case 2:
                    anim.SetTrigger("explosion");
                    StartCoroutine(Eliminarobjeto(2f));
                    break;
            }
        }
        else
        {
            StartCoroutine(Eliminarobjeto(0.5f));
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            ControlJugador.instance.rB.velocity = new Vector2(0, ControlJugador.instance.rB.velocity.y);
            anim.SetTrigger("explosion");
            StartCoroutine(Eliminarobjeto(2f));
        }
    }

    IEnumerator Eliminarobjeto(float itiempo)
    {
        yield return new WaitForSeconds(itiempo);
        Destroy(this.gameObject);
    }
}
