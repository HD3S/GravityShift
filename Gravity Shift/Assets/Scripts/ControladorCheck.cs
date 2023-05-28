using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCheck : MonoBehaviour
{
    public static ControladorCheck Instance;

    public Checkpoint[] checkpoints;

    public Vector3 puntoRespawn;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        checkpoints = FindObjectsOfType<Checkpoint>();

        puntoRespawn = ControlJugador.instance.transform.position;
    }
    
    public void DesactivarCheckpoints()
    {
        for (int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].ResetearCheckpoint();
        }
    }

    public void SetPuntoRespawn(Vector3 nuevoPuntoRespawn)
    {
        puntoRespawn = nuevoPuntoRespawn;
    }
}
