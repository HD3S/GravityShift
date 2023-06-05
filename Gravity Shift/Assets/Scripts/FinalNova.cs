using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalNova : MonoBehaviour
{
    [SerializeField] private AudioClip sonidoVictoria;
    public AudioSource musicaInGame;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ControladorSonidos.instance.EjecutarSonido(sonidoVictoria);
            musicaInGame.mute = true;
            ControlJugador.instance.velocidadMovimiento = 0;
            ControlJugador.instance.potenciaSalto = 0;
            Invoke("CargarFinal", 4f);
        }
    }
    void CargarFinal()
    {
        SceneManager.LoadScene("Final");
    }
}

