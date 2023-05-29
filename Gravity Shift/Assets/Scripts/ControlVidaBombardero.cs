using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVidaBombardero : MonoBehaviour
{

    public float vida;

    private Animator anim;
    private Rigidbody2D rb;

    ControlBombardero bombardero;

    [SerializeField] private AudioClip sonidoExplosion;

    // Start is called before the first frame update
    void Start()
    {
        vida = 20;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        bombardero = this.GetComponent<ControlBombardero>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ManejadorDano(float dano)
    {
        if (vida > 0)
        {
            vida -= dano;
        }
        else
        {
            Explosion();
        }
    }

    private void Explosion()
    {
        bombardero.velocidadMovimiento = 0;
        StartCoroutine(IniciarExplosion(.05f));//Llama al sonido explosion
        anim.SetTrigger("explosion");
        StartCoroutine(Eliminarobjeto(1f));
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
