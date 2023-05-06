using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlVidaJugador : MonoBehaviour
{
    public int vidaActual, vidaMax;

    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaMax;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Lava")
        {
            ManejadorDano();
        }
        
    }

    public void ManejadorDano()
    {
        vidaActual -= vidaMax;

        anim.SetTrigger("dano");

    }

    private void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
