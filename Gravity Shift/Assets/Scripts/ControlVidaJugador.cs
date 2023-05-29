using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlVidaJugador : MonoBehaviour
{
    public static ControlVidaJugador instance;

    public int vidaActual;
    private int vidaMax = 100;

    private float tiempoInvencibilidad = 1f;
    private float contadorInvencibilidad = 0;

    private Animator anim;
    private SpriteRenderer sr;

    [SerializeField] private AudioClip sonidoAcido;
    [SerializeField] private AudioClip sonidoMuerte;
    [SerializeField] private AudioClip sonidoDaño;



    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        vidaActual = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (vidaActual > vidaMax)
        {
            vidaActual = vidaMax;
        }

        if(contadorInvencibilidad > 0)
            contadorInvencibilidad -= Time.deltaTime; 

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Lava")
        {
            ManejadorDano("Lava");
            ControladorSonidos.instance.EjecutarSonido(sonidoAcido);
        }
        else if(collision.gameObject.tag == "Enemigo" || collision.gameObject.tag == "Monster" 
            || collision.gameObject.tag == "Bombardero" || collision.gameObject.tag == "Bomba")
        {
            ControladorSonidos.instance.EjecutarSonido(sonidoDaño);
            ManejadorDano(collision.gameObject.tag);
        }   
    }

    public void ManejadorDano(string itag)
    {
        int vidaMenos = 0;

        switch (itag)
        {
            case "Lava":
                vidaMenos = 100;
                break;
            case "Enemigo":
                vidaMenos = 10;
                break;
            case "Monster":
                vidaMenos = 80;
                break;
            case "Bombardero":
                vidaMenos = 20;
                break;
            case "Bomba":
                ControladorSonidos.instance.EjecutarSonido(sonidoDaño);
                vidaMenos = 40;
                break;
        }

        if (contadorInvencibilidad <= 0)
        {
            vidaActual -= vidaMenos;
            Vida.instance.RellenadorVida();
            if (vidaActual > 0)
            {
                anim.SetTrigger("dano");
                contadorInvencibilidad = tiempoInvencibilidad;

            }
            else
            {
                ControladorSonidos.instance.EjecutarSonido(sonidoMuerte);
                GameManager.instance.RespawnearJugador();
                vidaActual = vidaMax;
            }
        } 
    }
}
