using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBala : MonoBehaviour
{
    private float fuerza;

    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        fuerza = 3.5f;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        Vector3 direccion = ControlJugador.instance.transform.position;

        if (ControlJugador.instance.sR.flipX)
        {
            rb.velocity = new Vector2(-fuerza, direccion.y);
        }
        else
        {
            rb.velocity = new Vector2(fuerza, direccion.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "Bala" 
            && collision.gameObject.tag != "Green" 
            && collision.gameObject.tag != "Blue" 
            && collision.gameObject.tag != "Red"
            && collision.gameObject.tag != "White"
            && collision.gameObject.tag != "Coleccionable")
        {
            anim.SetTrigger("colision");
            rb.velocity = new Vector2(0, rb.velocity.y);

            if (collision.gameObject.tag == "Enemigo")
            {
                ControlVidaEnemigo enemigo = collision.GetComponent<ControlVidaEnemigo>();
                enemigo.ManejadorDano(10);
            }else if(collision.gameObject.tag == "Monster")
            {
                ControlVidaMonster monster = collision.GetComponent<ControlVidaMonster>();
                monster.ManejadorDano(10);
            }else if(collision.gameObject.tag == "Bombardero")
            {
                ControlVidaBombardero bombardero = collision.GetComponent<ControlVidaBombardero>();
                bombardero.ManejadorDano(10);
            }

            StartCoroutine(EliminarObjeto(0.2f));
        }
    }

    IEnumerator EliminarObjeto(float itiempo)
    {
        yield return new WaitForSeconds(itiempo);
        Destroy(this.gameObject);
    }
}
