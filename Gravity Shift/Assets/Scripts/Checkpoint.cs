using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public SpriteRenderer sR;

    public Sprite cpOn, cpOff;

    [SerializeField] private AudioClip sonidoCheckPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(sR.sprite == cpOff)
            {
                ControladorSonidos.instance.EjecutarSonido(sonidoCheckPoint);
            }
            ControladorCheck.Instance.DesactivarCheckpoints();
            sR.sprite = cpOn;
            ControladorCheck.Instance.SetPuntoRespawn(transform.position);
        }
    }

    public void ResetearCheckpoint()
    {
        sR.sprite = cpOff;
    }
}
