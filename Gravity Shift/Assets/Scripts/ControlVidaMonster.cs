using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVidaMonster : MonoBehaviour
{
    public static ControlVidaMonster instance;
    public float vida;
    private int contadorGolpes = 0;//para que solo explote una vez

    private Animator anim;
    private Rigidbody2D rb;

    ControlEnemigo enemigo;

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
        if (vida > 0)
        {
            if (contadorGolpes == 0)
            {
                contadorGolpes++;
                enemigo.velocidadMovimiento = 0;
                anim.SetTrigger("explosion");
                StartCoroutine(IniciarExplosion(0.8f));//Llama al sonido explosion
                StartCoroutine(Eliminarobjeto(2.5f));
            }
        
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (contadorGolpes == 0)
            {
                contadorGolpes++;
                enemigo.velocidadMovimiento = 0;
                StartCoroutine(IniciarExplosion(0.8f));//Llama al sonido explosion
                anim.SetTrigger("explosion");
                StartCoroutine(Eliminarobjeto(2.5f));
            }
        }
    }

    IEnumerator Eliminarobjeto(float itiempo)
    {
        yield return new WaitForSeconds(itiempo);
        Destroy(this.gameObject);
    }

    IEnumerator IniciarExplosion(float itiempo)
    {
        yield return new WaitForSeconds(itiempo);
        ControladorSonidos.instance.EjecutarSonido(sonidoExplosion);//Efecto de sonido explosion
    }
}

