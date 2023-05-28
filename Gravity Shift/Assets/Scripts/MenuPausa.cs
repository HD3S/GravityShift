using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject menuPausa = null;
    [SerializeField] private AudioSource musicaInGame;
    [SerializeField] private AudioClip sonidoPausa;
    [SerializeField] private AudioClip sonidoReanudar;
    [SerializeField] private AudioClip sonidoReset;

    Boolean pausado=false;

    public void Start()
    {
    }
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            
            Time.timeScale = 0f;
            if(!pausado) 
                ControladorSonidos.instance.EjecutarSonido(sonidoPausa);
            pausado = true;
            musicaInGame.Pause();
            menuPausa.SetActive(true);
        }
    }
    public void Reanudar() 
    {
        pausado=false;
        Time.timeScale = 1f;
        ControladorSonidos.instance.EjecutarSonido(sonidoReanudar);
        musicaInGame.Play();
        menuPausa.SetActive(false);
    }

    public void Reset()
    {
        Time.timeScale = 1f;
        ControladorSonidos.instance.EjecutarSonido(sonidoReset);
        SceneManager.LoadScene("Nave");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
