using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControlInicio : MonoBehaviour
{

    public AudioClip sonidoStart;

    private bool yaPulsado;

    // Update is called once per frame
    void Update()
    {

        //Si se presiona enter se carga la escena principal
        if (Input.GetButtonDown("Submit"))
        {
            if (!yaPulsado)
            {
                AudioSource.PlayClipAtPoint(sonidoStart, Vector3.zero);
                Invoke("CargarEscena", 0.25f);
                yaPulsado= true;
            }


        }
        if (Input.GetButtonDown("Cancel"))
        {
            //Cierra la aplicacion
            Application.Quit();
        }
    }

    void CargarEscena()
    {
        //Carga la escena de juego
        SceneManager.LoadScene("Nave");
    }

}
