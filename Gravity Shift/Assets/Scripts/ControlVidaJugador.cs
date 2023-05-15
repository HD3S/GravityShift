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
            ManejadorDano("Lava");
        else if(collision.gameObject.tag == "Enemigo")
            ManejadorDano("Enemigo");
        
    }

    public void ManejadorDano(string itipo)
    {
        int vidaMenos = 0;

        switch (itipo)
        {
            case "Lava":
                vidaMenos = 100;
                break;
            case "Enemigo":
                vidaMenos = 20;
                break;
        }

        if (contadorInvencibilidad <= 0)
        {
            vidaActual -= vidaMenos;
            if (vidaActual > 0)
            {
                anim.SetTrigger("dano");
                contadorInvencibilidad = tiempoInvencibilidad;

            }
            else
            {
                GameManager.instance.RespawnearJugador();

            }
        } 
    }
}
