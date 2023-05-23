using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBomba : MonoBehaviour
{
    private float fuerza;

    private Rigidbody2D rb;
    private Animator anim;
    public LayerMask suelo;

    // Start is called before the first frame update
    void Start()
    {
        fuerza = 0.25f;
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
        int layer = collision.gameObject.layer;
        Debug.Log(layer);
        if(layer == 7)
        {
            fuerza = 0;
            anim.SetTrigger("explosion");
            //StartCoroutine(EliminarObjeto(2f));
        }
    }

    IEnumerator EliminarObjeto(float itiempo)
    {
        yield return new WaitForSeconds(itiempo);
        Destroy(this.gameObject);
    }
}
