using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControlInicio : MonoBehaviour
{

    public AudioClip sfxButton;

    private bool oneshotSfx;

    // Update is called once per frame
    void Update()
    {

        //Si se presiona enter se carga la escena principal
        if (Input.GetButtonDown("Submit"))
        {
            if (!oneshotSfx)
            {
                AudioSource.PlayClipAtPoint(sfxButton, Vector3.zero);
                Invoke("CargarEscena", 0.5f);
                oneshotSfx = true;
            }


        }

    }

    void CargarEscena()
    {
        //Carga la escena de juego
        SceneManager.LoadScene("Nave");
    }

}
