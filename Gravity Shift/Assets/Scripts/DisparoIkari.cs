using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoIkari : MonoBehaviour
{
    public GameObject balaIkari;
    public Transform posicionDisparo;
    private Animator anim;

    [SerializeField] private AudioClip sonidoLaserGun;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Disparo();
        }
    }

    private void Disparo()
    {
        if (Mathf.Abs(ControlJugador.instance.rB.velocity.x) > .9)
        {
            anim.SetTrigger("disparoMov");
        }
        else
        {
            anim.SetTrigger("disparoSinMov");
        }

        ControladorSonidos.instance.EjecutarSonido(sonidoLaserGun);
        Instantiate(balaIkari, posicionDisparo.position, Quaternion.identity);
    }

}
