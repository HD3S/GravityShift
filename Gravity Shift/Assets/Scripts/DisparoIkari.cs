using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoIkari : MonoBehaviour
{
    public GameObject balaIkari;
    public Transform posicionDisparo;
    private Animator anim;

    [SerializeField] private AudioClip sonidoLaserGun;

    private float tiempo;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //tiempo += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.P))
        {
            Disparo();
            ControladorSonidos.instance.EjecutarSonido(sonidoLaserGun);
        }
    }

    private void Disparo()
    {
        if (Mathf.Abs(ControlJugador.instance.rB.velocity.x) > 0)
        {
            anim.SetTrigger("disparoMov");
        }
        else
        {
            anim.SetTrigger("disparo");
        }
        
        Instantiate(balaIkari,posicionDisparo.position, Quaternion.identity);
    }
}
