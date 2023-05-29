using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBomba : MonoBehaviour
{
    private float fuerza;

    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        fuerza = 0.75f;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        rb.velocity = new Vector2(transform.position.x, -fuerza);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Suelo"))
        {
            fuerza = 0;
            rb.velocity = new Vector2(transform.position.x, 0);
            anim.SetTrigger("explosion");
            StartCoroutine(EliminarObjeto(.95f));
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            ControlVidaJugador.instance.ManejadorDano("Bomba");
        }
    }

    IEnumerator EliminarObjeto(float itiempo)
    {
        yield return new WaitForSeconds(itiempo);
        Destroy(this.gameObject);
    }
}
