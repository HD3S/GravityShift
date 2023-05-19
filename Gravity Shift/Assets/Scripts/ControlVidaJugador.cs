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
            ManejadorDano("Lava",0);
        else if(collision.gameObject.tag == "Enemigo")
        {
            ControlEnemigo enemigo = collision.gameObject.GetComponent<ControlEnemigo>();

            ManejadorDano("Enemigo",enemigo.tipoEnemigo);
        }
            
        
    }

    public void ManejadorDano(string itag,int itipo)
    {
        int vidaMenos = 0;

        switch (itag)
        {
            case "Lava":
                vidaMenos = 100;
                break;
            case "Enemigo":
                if (itipo == 0)
                    vidaMenos = 10;
                else if (itipo == 1)
                    vidaMenos = 20;
                else
                    vidaMenos = 100;
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
                GameManager.instance.RespawnearJugador();
                vidaActual = vidaMax;
            }
        } 
    }
}
