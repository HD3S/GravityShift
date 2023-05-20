using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject menuPausa = null;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Time.timeScale = 0f;
            menuPausa.SetActive(true);
        }
    }
    public void Reanudar() 
    {
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
    }

    public void Reset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Nave");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
