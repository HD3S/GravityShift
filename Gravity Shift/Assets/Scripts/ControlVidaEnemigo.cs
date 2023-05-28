using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVidaEnemigo : MonoBehaviour
{
    public static ControlVidaEnemigo instance;

    public float vida;

     private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        vida = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (vida < 0)
            ManejadorDano(0);
    }

    public void ManejadorDano(float dano)
    {
        if(vida > 0)
        {
            vida -= dano;
        }
        else
        {
            StartCoroutine(Eliminarobjeto(0.5f));
        }
    }

    IEnumerator Eliminarobjeto(float itiempo)
    {
        yield return new WaitForSeconds(itiempo);
        Destroy(this.gameObject);
    }
}
