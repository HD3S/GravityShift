using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    public int Green = 1;
    public int Blue = 5;
    public int Red = 10;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (this.CompareTag("Green"))
            {
                gameManager.SumarPuntos(Green);
                Destroy(this.gameObject);
            }
            if (this.CompareTag("Blue"))
            {
                gameManager.SumarPuntos(Blue);
                Destroy(this.gameObject);
            }
            if (this.CompareTag("Red"))
            {
                gameManager.SumarPuntos(Red);
                Destroy(this.gameObject);
            }
        }
    }
}
