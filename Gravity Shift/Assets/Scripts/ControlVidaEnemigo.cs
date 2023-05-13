using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVidaEnemigo : MonoBehaviour
{
    public static ControlVidaEnemigo instance;

    public float vida;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        vida = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(vida <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void ManejadorDano(float dano)
    {
        if(vida > 0)
        {
            vida -= dano;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }
}
