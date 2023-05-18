using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVidaEnemigo : MonoBehaviour
{
    public static ControlVidaEnemigo instance;

    public float vida;
    public int tipoEnemigo;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        vida = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(vida <= 0)
        {
            ManejadorDano(0);
        }
    }

    public void ManejadorDano(float dano)
    {
        if(vida > 0)
        {
            switch (tipoEnemigo)
            {
                case 0:
                    vida -= dano;
                    break;
                case 1:
                    vida -= dano;
                    //add animation
                    break;
                case 2:
                    vida -= dano;
                    //add animation
                    break;
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }
}
