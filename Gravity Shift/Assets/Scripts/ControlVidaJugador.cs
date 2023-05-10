using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlVidaJugador : MonoBehaviour
{
    public static ControlVidaJugador instance;

    public int vidaActual;
    private int vidaMax = 100;

    private float tiempoInvencibilidad = 0.75f;
    private float contadorInvencibilidad = 0;

    Vector2 posicionInicial;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaMax;
        posicionInicial = ControlJugador.instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (vidaActual > vidaMax)
        {
            vidaActual = vidaMax;
        }
        if(vidaActual <= 0)
        {
            StartCoroutine(Reiniciar(3.5f));
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
        
        if (contadorInvencibilidad <= 0)
        {
            switch (itipo)
            {
                case "Lava":
                    ControlJugador.instance.anim.SetTrigger("dano");
                    vidaMenos = 10;
                    break;
                case "Enemigo":
                    ControlJugador.instance.anim.SetTrigger("dano");
                    vidaMenos = 20;
                    break;
            }

            vidaActual -= vidaMenos;

            StartCoroutine(Respawn(0.8f));
        }
        else
        {
            contadorInvencibilidad = tiempoInvencibilidad;
        }
    }

    IEnumerator Respawn(float itiempo)
    {
        ControlJugador.instance.velocidadMovimiento = 0;
        ControlJugador.instance.potenciaSalto = 0;

        yield return new WaitForSeconds(itiempo);

        ControlJugador.instance.velocidadMovimiento = 1.25f;
        ControlJugador.instance.potenciaSalto = 1;
        ControlJugador.instance.transform.position = posicionInicial;
    }

    IEnumerator Reiniciar(float itiempo)
    {
        yield return new WaitForSeconds(itiempo);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
