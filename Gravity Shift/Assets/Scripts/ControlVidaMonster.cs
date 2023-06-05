using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVidaMonster : MonoBehaviour
{
    public static ControlVidaMonster instance;

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
        if (contadorGolpes == 0)
        {
            Explosion();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (contadorGolpes == 0)
            {
                Explosion();
            }
        }
    }

    private void Explosion()
    {
        contadorGolpes++;
        enemigo.velocidadMovimiento = 0;
        StartCoroutine(IniciarExplosion(0.8f));//Llama al sonido explosion
        anim.SetTrigger("explosion");
        StartCoroutine(Eliminarobjeto(2.5f));
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

