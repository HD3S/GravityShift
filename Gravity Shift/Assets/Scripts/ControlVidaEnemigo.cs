using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVidaEnemigo : MonoBehaviour
{
    public static ControlVidaEnemigo instance;

    public float vida;

    ControlEnemigo enemigo;

    private Animator anim;
    private Rigidbody2D rb;

    [SerializeField] private AudioClip sonidoExplosion;


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
        enemigo = this.GetComponent<ControlEnemigo>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ManejadorDano(float dano)
    {
        if(vida > 0)
        {
            switch (enemigo.tipoEnemigo)
            {
                case 1:
                    vida -= dano;
                    break;
                case 2:
                    vida -= dano;
                    //add animation
                    break;
                case 3:
                    enemigo.velocidadMovimiento = 0;
                    anim.SetTrigger("explosion");
                    StartCoroutine(IniciarExplosion(0.8f));//Llama al sonido explosion
                    StartCoroutine(Eliminarobjeto(2.5f));
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
            
            enemigo.velocidadMovimiento = 0;
            StartCoroutine(IniciarExplosion(0.8f));//Llama al sonido explosion
            anim.SetTrigger("explosion");
            StartCoroutine(Eliminarobjeto(2.5f));
        }
    }

    IEnumerator Eliminarobjeto(float itiempo)
    {
        yield return new WaitForSeconds(itiempo);
        Destroy(this.gameObject);
    }

    IEnumerator IniciarExplosion(float itiempo)
    {
        yield return new WaitForSeconds (itiempo);
        ControladorSonidos.instance.EjecutarSonido(sonidoExplosion);//Efecto de sonido explosion
    }
}
