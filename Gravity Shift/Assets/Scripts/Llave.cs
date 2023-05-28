using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
    public GameManager gamemanager;
    [SerializeField] private AudioClip recogerLlave;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gamemanager.SumarLlave();
            ControladorSonidos.instance.EjecutarSonido(recogerLlave);
            Destroy(this.gameObject);
        }
    }
}
